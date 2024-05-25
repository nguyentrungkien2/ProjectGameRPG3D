using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamePlayerManager : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBarPlayer healthBar;
    private Animator animator;
    [SerializeField] private GameObject gameOverObject;
    private TimeManager timeManager;
    private void Start()
    {
        timeManager=FindObjectOfType<TimeManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealthPlayer(maxHealth);
        animator = GetComponent<Animator>();
    }
    public void TakeDame(int dame)
    {
        currentHealth -= dame;
        if(currentHealth<=0)
        {
            animator.SetBool("Die", true);
            StartCoroutine(DisplayGameOver());
        }    
        healthBar.SetHealthPlayer(currentHealth);
    }

    public void DamePlayer(int takeDamePlayer)
    {
        TakeDame(takeDamePlayer);
    }
    IEnumerator DisplayGameOver()
    {
        yield return new WaitForSecondsRealtime(1);
        timeManager.PauseTime();
        gameOverObject.SetActive(true);
    }    
}
