using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthBarBossManager : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBarEnemy healthBar;
    private Animator animatorBoss;
    private bool isDead = false; // Biến để kiểm tra xem enemy đã chết chưa
    private int timeDestroyEnemy = 5;
    [SerializeField] private GameObject completedLevel02;
    private TimeManager timeManager;


    public void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealthEnemy(maxHealth);
        animatorBoss = GetComponent<Animator>();
    }

    public void TakeDame(int dame)
    {
        if (!isDead) // Kiểm tra nếu enemy chưa chết mới gây damage
        {
            currentHealth -= dame;
            healthBar.SetHealthEnemy(currentHealth);
            if (currentHealth <= 0)
            {
                QuestManager.SubQuestNumber = 0;
                animatorBoss.SetBool("die", true);
                StartCoroutine(EnemyDie());
            }
        }
    }
    public IEnumerator EnemyDie()
    {
        isDead = true; // Đánh dấu enemy đã chết
        yield return new WaitForSecondsRealtime(timeDestroyEnemy);
        completedLevel02.gameObject.SetActive(true);
        if (timeManager != null)
        {
            timeManager.PauseTime();
            timeManager.SetGameFinished(); // Đặt trạng thái của trò chơi khi màn chơi hoàn thành
        }
    }
}
