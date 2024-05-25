using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour
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

    //[SerializeField] private ParticleSystem hitBySword;
    public ParticleSystem DragonAttack01;
    [SerializeField] private GameObject positionSlash01;

    private float destroyParticle = 1.5f;
    private BoxCollider boxCollider;
    private Vector3 distanceWithPlayer = new Vector3(0, 0, 4);
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        takeDamePlayer = GameObject.Find("Player").GetComponent<TakeDamePlayerManager>();
    }

    void Update()
    {
      FollowPlayer();
 
    }
    void FollowPlayer()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange)
            {
                EnemySpeed = 0.1f;
                if (AttackTrigger == 0)
                {
                    animator.SetBool("Attack", false);
                    animator.SetFloat("Move",1);
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position + distanceWithPlayer, EnemySpeed);
                }
            }
            else
            {
                EnemySpeed = 0;
            }
            Attack();
        }
    }    
    public void Attack()
    {
        // Giảm thời gian cooldown trước khi tấn công tiếp theo
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            if (AttackTrigger == 1)
            {
                EnemySpeed = 0;
                animator.SetBool("Attack", true);
                animator.SetFloat("Move", 0);
                attackTimer = attackCooldown; // Reset thời gian cooldown
                AttackTrigger = 0;
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
            FollowPlayer();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("First Sword"))
        {
            animator.SetBool("Attack", false);
            animator.SetFloat("Move", 0);
        }
    }
    public void DragonAttacking01()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(DragonAttack01, positionSlash01.transform.position, positionSlash01.transform.rotation);
        float destroyDelay = destroyParticle;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }

    private IEnumerator DestroyParticle(ParticleSystem particle, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(particle.gameObject);
    }
    public void DisableBoxCollider()
    {
        boxCollider.enabled = false;
    }
    public void OnableBoxCollider()
    {
        boxCollider.enabled = true;
    }

}
