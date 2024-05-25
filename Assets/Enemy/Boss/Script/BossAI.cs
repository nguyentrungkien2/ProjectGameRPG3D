using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    //player object
    public GameObject followTargetPlayer;

    //enemy
    public Rigidbody enemyRigidbody;

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
    public ParticleSystem bossAttack01;
    [SerializeField] private GameObject positionAttack01;

    //particle attack
    public ParticleSystem bossAttack02;
    [SerializeField] private GameObject positionAttack02;

    //particle attack
    public ParticleSystem bossAttack03;
    [SerializeField] private GameObject positionAttack03;

    private float destroyParticalTime = 0.5f;
    //particle get hit by PLayer's Sword
    public ParticleSystem vfxGetBySword;
    [SerializeField] private GameObject positionVfxGetBySword;


    // biến kiểm tra trạng thái tấn công của boss
    private bool isAttacking = false;

    //distance player
    private Vector3 distanceWithPlayer = new Vector3(1, 0, 0);

    private int randomAttack;
    // Start is called before the first frame update
    void Start()
    {
        //tham chiếu các component và thực hiện kiểm tra nếu missing component
        animator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();
        followTargetPlayer = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        takeDamePlayer = followTargetPlayer.GetComponent<TakeDamePlayerManager>();

        if (animator == null) Debug.LogError("Animator component is missing!");
        if (enemyRigidbody == null) Debug.LogError("Rigidbody component is missing!");
        if (followTargetPlayer == null) Debug.LogError("Player GameObject is missing or not named 'Player'!");
        if (navMeshAgent == null) Debug.LogError("NavMeshAgent component is missing!");
        if (takeDamePlayer == null) Debug.LogError("TakeDamePlayerManager component on the Player GameObject is missing!");
    }

    void Update()
    {
        FollowTargetPlayer();
        if (!isAttacking)
        {
            AttackEnemy();
        }
    }


    public void FollowTargetPlayer()
    {
        Vector3 direction = (followTargetPlayer.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        navMeshAgent.SetDestination(followTargetPlayer.transform.position + distanceWithPlayer);

        animator.SetFloat("move", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
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
            isAttacking = true;

            // Chọn ngẫu nhiên một trigger để kích hoạt animation tấn công
            randomAttack  = Random.Range(2, 5); // Giả sử bạn có 3 kiểu tấn công
            switch (randomAttack)
            {
                 case 2:
                    animator.SetTrigger("attack02");
                    break;
                case 3:
                    animator.SetTrigger("attack03");
                    break;
                case 4:
                    animator.SetTrigger("attack04");
                    break;
            }

            attackTimer = attackCooldown;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("First Sword"))
        {
            animator.SetTrigger("get hit");
        }
    }
    public void GetHitByPlayer()
    {
        ParticleSystem newParticle = Instantiate(vfxGetBySword, positionAttack03.transform.position, positionAttack01.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void BossAttacking01()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bossAttack01, positionAttack01.transform.position, positionAttack01.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void BossAttacking02()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bossAttack02, positionAttack02.transform.position, positionAttack02.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    public void BossAttacking03()
    {
        takeDamePlayer.DamePlayer(damePlayer);
        ParticleSystem newParticle = Instantiate(bossAttack03, positionAttack03.transform.position, positionAttack03.transform.rotation);
        float destroyDelay = destroyParticalTime;
        StartCoroutine(DestroyParticle(newParticle, destroyDelay));
    }
    private IEnumerator DestroyParticle(ParticleSystem particle, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(particle.gameObject);
    }
}
