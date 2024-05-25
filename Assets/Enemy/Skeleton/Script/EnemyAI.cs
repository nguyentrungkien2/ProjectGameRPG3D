using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //player object
    public GameObject followTargetPlayer;

    //enemy
    public Rigidbody rb;
    private float speedEnemy=3.0f;

    //animator
    private Animator animator;
    
    //NavMesh AI
    private NavMeshAgent navMeshAgent;
    private float speedRatio;
    
    //Take dame player
    private TakeDamePlayerManager takeDamePlayer;
    private int damePlayer = 1;

    //attack
    private int attackTrigger;

    //check time Attack
    private float attackCooldown = 1.0f; // Thời gian giữa các tấn công (giây)
    private float attackTimer = 0.0f; // Đếm thời gian từ lần tấn công trước đó

    //particle attack
    public ParticleSystem skeletonAttack01;
    [SerializeField] private GameObject positionSlash01;
    private float destroyParticalTime = 0.5f;
    //particle get hit by PLayer's Sword
    public ParticleSystem vfxGetBySword;
    [SerializeField] private GameObject positionVfxGetBySword;

    // Start is called before the first frame update
    void Start()
    {
        //get componet from start
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        followTargetPlayer = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        takeDamePlayer = GameObject.Find("Player").GetComponent<TakeDamePlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTargetPlayer();
        AttackEnemy();
    }

    //follow player with NavMesh Agent
    public void FollowTargetPlayer()
    {
        rb.transform.LookAt(followTargetPlayer.transform.position);
        speedRatio= rb.velocity.magnitude / speedEnemy;
        animator.SetFloat("Move",rb.velocity.magnitude/speedEnemy);
        navMeshAgent.SetDestination(followTargetPlayer.transform.position);
    }

    //check collision with player and turn on attack state
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackTrigger = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackTrigger = 0;
        }
    }

    private void AttackEnemy()
    {
        if (attackTrigger == 1)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("Move", -1.0f);
                attackTimer = attackCooldown; // Reset thời gian cooldown
            }
        }
    }
    public IEnumerator OnTriggerStayCoroutine(Collider other)
    {
        // Kiểm tra nếu AttackTrigger không được kích hoạt và va chạm với "First Sword"
        if (other.gameObject.CompareTag("First Sword"))
        {
            animator.SetBool("Get Hit", true);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("Get Hit", false);
        }
    }
    public void OnTriggerStay(Collider other)
    {
            StartCoroutine(OnTriggerStayCoroutine(other));
    }
    public void GetHitByPlayer()
    {
        ParticleSystem newParticle = Instantiate(vfxGetBySword, positionVfxGetBySword.transform.position, positionVfxGetBySword.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void SkeletonAttacking01()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(skeletonAttack01, positionSlash01.transform.position, positionSlash01.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    private IEnumerator DestroyParticle(ParticleSystem particle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(particle.gameObject);
    }
}
