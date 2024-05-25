using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBossAndEnemyDisplay : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private List<GameObject> enemy;

    [SerializeField] private GameObject texBoxBoss;
    [SerializeField] private GameObject textDescriptionBoss;

    //textbox player
    [SerializeField] private GameObject texBoxPlayer;
    [SerializeField] private GameObject textDescriptionPlayer;

    private const float bossTalkDuration = 9f;
    private const float playerTalkDuration = 10f;
    private const float initialWaitTime = 2f;
    private RandomEnemy randomEnemy;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TalkingPlayerAndBoss());
        }
    }
    private void Start()
    {
        randomEnemy=GameObject.Find("posRandomEnemy").GetComponent<RandomEnemy>();
    }
    public void InstanceBossAndEnemy()
    {
        if (enemy != null && enemy.Count > 0)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                randomEnemy.remainingEnemyCount = 2;
                // Ví dụ: tạo các đối tượng tại các vị trí khác nhau bằng cách dịch chuyển dọc theo trục x
                Vector3 spawnPosition = boss.transform.position + new Vector3(i * 2.0f, 0, 0);
                Instantiate(enemy[i], spawnPosition, transform.rotation);
                Debug.Log($"Instantiated enemy at index {i} at position {spawnPosition}");
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogWarning("Enemy list is empty or null. Please check again!");
        }

        if (boss != null)
        {
            boss.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Boss GameObject is not assigned.");
        }
    }
    IEnumerator TalkingPlayerAndBoss()
    {
        yield return new WaitForSeconds(initialWaitTime);
        if (texBoxBoss != null && textDescriptionBoss != null)
        {
            texBoxBoss.SetActive(true);
            textDescriptionBoss.SetActive(true);
        }
        else
        {
            Debug.Log("Object in inpector is null splease check again");
        }
        yield return new WaitForSeconds(bossTalkDuration);

        if (texBoxBoss != null && textDescriptionBoss != null)
        {
            texBoxBoss.SetActive(false);
            textDescriptionBoss.SetActive(false);
        }
        if (texBoxPlayer != null && textDescriptionPlayer != null)
        {
            texBoxPlayer.SetActive(true);
            textDescriptionPlayer.SetActive(true);
        }
        else
        {
            Debug.Log("Object in inpector is null splease check again");
        }
        yield return new WaitForSeconds(playerTalkDuration);

        InstanceBossAndEnemy();
        texBoxPlayer.SetActive(false);
        textDescriptionPlayer.SetActive(false);

    }
}
