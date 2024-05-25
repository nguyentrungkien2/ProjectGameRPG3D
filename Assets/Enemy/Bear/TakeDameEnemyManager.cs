using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeDameEnemyManager : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;
    public HealthBarEnemy healthBar;
    private Animator animatorEnemy;

    [SerializeField] private GameObject NPCMagician;
    [SerializeField] private GameObject eventBearDie;

    private bool isDead = false; // Biến để kiểm tra xem enemy đã chết chưa

    public void Start()
    {
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
                animatorEnemy.SetBool("dealth", true);
                animatorEnemy.SetBool("Attack", false);
                animatorEnemy.SetBool("Run Forward", false);
                StartCoroutine(EnemyDie());
            }
        }
    }

    public IEnumerator EnemyDie()
    {
        isDead = true; // Đánh dấu enemy đã chết
        yield return new WaitForSeconds(4);
        eventBearDie.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
