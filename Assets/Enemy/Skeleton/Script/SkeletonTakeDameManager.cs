using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonTakeDameManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBarEnemy healthBar;
    private Animator animatorEnemy;
    private bool isDead = false; // Biến để kiểm tra xem enemy đã chết chưa
    private int timeDestroyEnemy = 3;
    private RandomEnemy randomEnemy;
    public void Start()
    {
        randomEnemy = GameObject.Find("posRandomEnemy").GetComponent<RandomEnemy>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealthEnemy(maxHealth);
        animatorEnemy = GetComponent<Animator>();
    }

    public void TakeDame(int dame)
    {
        if (!isDead) // Kiểm tra nếu enemy chưa chết mới gây damage
        {
            currentHealth -= dame;
            healthBar.SetHealthEnemy(currentHealth);
            if (currentHealth <= 0)
            {
                QuestManager.SubQuestNumber = 2;
                randomEnemy.EnemyDestroyed();
                animatorEnemy.SetBool("Die", true);
                StartCoroutine(EnemyDie());
            }
        }
    }
    public IEnumerator EnemyDie()
    {
        isDead = true; // Đánh dấu enemy đã chết
        yield return new WaitForSecondsRealtime(timeDestroyEnemy);
        Destroy(gameObject);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class SkeletonTakeDameManager : MonoBehaviour
//{
//    public int maxHealth = 3;
//    public int currentHealth;
//    public HealthBarEnemy healthBar;
//    private Animator animatorEnemy;
//    private bool isDead = false; // Biến để kiểm tra xem enemy đã chết chưa
//    private int timeDestroyEnemy = 3;
//    private RandomEnemy randomEnemy;

//    void Start()
//    {
//        randomEnemy = GameObject.Find("posRandomEnemy").GetComponent<RandomEnemy>();
//        if (randomEnemy == null)
//        {
//            Debug.LogWarning("RandomEnemy component not found on 'posRandomEnemy'!");
//        }

//        currentHealth = maxHealth;
//        healthBar.SetMaxHealthEnemy(maxHealth);
//        animatorEnemy = GetComponent<Animator>();
//    }

//    public void TakeDame(int dame)
//    {
//        if (!isDead) // Kiểm tra nếu enemy chưa chết mới gây damage
//        {
//            currentHealth -= dame;
//            healthBar.SetHealthEnemy(currentHealth);
//            if (currentHealth <= 0)
//            {
//                QuestManager.SubQuestNumber = 2;
//                if (randomEnemy != null)
//                {
//                    randomEnemy.EnemyDestroyed(gameObject);
//                }
//                animatorEnemy.SetBool("Die", true);
//                if (gameObject.activeInHierarchy)
//                {
//                    StartCoroutine(EnemyDie());
//                }
//            }
//        }
//    }

//    private IEnumerator EnemyDie()
//    {
//        isDead = true; // Đánh dấu enemy đã chết
//        yield return new WaitForSecondsRealtime(timeDestroyEnemy);
//        Destroy(gameObject);
//    }
//}
