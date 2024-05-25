using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BearAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 40;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    private Animator animator;

    private float attackCooldown = 1.0f; // Thời gian giữa các tấn công (giây)
    private float attackTimer = 0.0f; // Đếm thời gian từ lần tấn công trước đó

    private TakeDamePlayerManager takeDamePlayer;
    private int damePlayer = 1;

    private float stopSpeedBear = 0.0f;
    private float destroyParticalTime = 0.5f;

    [SerializeField] private ParticleSystem hitBySword;

    public ParticleSystem bearAttack01;
    public ParticleSystem bearAttack02;
    public ParticleSystem bearAttack03;
    [SerializeField] private GameObject positionSlash01;
    [SerializeField] private GameObject positionSlash02;
    [SerializeField] private GameObject positionSlash03;


    private void Start()
    {
        animator = GetComponent<Animator>();
        takeDamePlayer = GameObject.Find("Player").GetComponent<TakeDamePlayerManager>();
    }

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange)
            {
                EnemySpeed = 0.05f;
                if (AttackTrigger == 0)
                {
                    animator.SetBool("Run Forward", true);
                    hitBySword.Stop();
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else
            {
                EnemySpeed = stopSpeedBear;
                animator.SetBool("Combat Idle", true);
                hitBySword.Stop();
            }
        }
        Attack();
    }
    public void Attack()
    {
        // Kiểm tra nếu AttackTrigger đã được kích hoạt trước khi giảm thời gian cooldown
        if (AttackTrigger == 1)
        {
            // Giảm thời gian cooldown trước khi tấn công tiếp theo
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                EnemySpeed = stopSpeedBear;
                hitBySword.Stop();
                animator.SetBool("Attack", true);
                animator.SetBool("Run Forward", false);
                attackTimer = attackCooldown; // Reset thời gian cooldown
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AttackTrigger = 1;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AttackTrigger = 0;
        }
    }
    public IEnumerator OnTriggerStayCoroutine(Collider other)
    {
        // Kiểm tra nếu AttackTrigger không được kích hoạt và va chạm với "First Sword"
        if (other.gameObject.CompareTag("First Sword"))
        {
            hitBySword.Play();
            animator.SetBool("Get Hit", true);
            animator.SetBool("Attack", false);
            animator.SetBool("Run Forward", false);
            yield return new WaitForSeconds(0.4f);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        StartCoroutine(OnTriggerStayCoroutine(other));
    }
    public void BearAttacking01()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bearAttack01, positionSlash01.transform.position, positionSlash01.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void BearAttacking02()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bearAttack02, positionSlash02.transform.position, positionSlash02.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void BearAttacking03()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bearAttack03, positionSlash03.transform.position, positionSlash03.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    private IEnumerator DestroyParticle(ParticleSystem particle, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(particle.gameObject);
    }
}
