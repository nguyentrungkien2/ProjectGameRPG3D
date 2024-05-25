
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int posX;
    private int posZ;
    public int enemyCount;
    private int maxEnemyCount = 20;
    public int remainingEnemyCount; // Số lượng enemy còn lại
    public TMP_Text enemyCountText;
    private int postMin = 10;
    private int postMax = 230;
    private int postZ = 55;

    //Quest 01 quest 01 finished
    [SerializeField] private GameObject quest01Finished;

    private void Start()
    {
        remainingEnemyCount = maxEnemyCount;
        UpdateEnemyCountText(); // Cập nhật UI Text object ban đầu
    }

    public void StartRandomEnemy()
    {
        StartCoroutine(RandomEnemyCoroutine());
    }

    IEnumerator RandomEnemyCoroutine()
    {
        while (enemyCount < maxEnemyCount - 1)
        {
            posX = UnityEngine.Random.Range(postMin, postMax);
            Instantiate(enemyPrefab, new Vector3(posX, 0, postZ), transform.rotation);
            enemyCount++;
            UpdateEnemyCountText(); // Cập nhật số lượng enemy còn lại sau khi instance một enemy
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    // Hàm này được gọi khi một enemy bị hủy bỏ
    public void EnemyDestroyed()
    {
        remainingEnemyCount--;
        UpdateEnemyCountText(); // Cập nhật số lượng enemy còn lại

        if (remainingEnemyCount == 0)
        {
            OnAllEnemiesDestroyed();
        }
    }

    // Hàm để cập nhật UI Text object hiển thị số lượng enemy còn lại
    private void UpdateEnemyCountText()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = "" + remainingEnemyCount;
        }
    }

    // Hàm để xử lý sự kiện khi tất cả các enemy bị hủy bỏ
    private void OnAllEnemiesDestroyed()
    {
        QuestManager.SubQuestNumber = 1;
        quest01Finished.SetActive(true);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class RandomEnemy : MonoBehaviour
//{
//    [SerializeField] private GameObject enemyPrefab;
//    [SerializeField] private TMP_Text enemyCountText;
//    [SerializeField] private GameObject quest01Finished;

//    private int posX;
//    private int posZ = 55;
//    private int enemyCount;
//    private int maxEnemyCount = 20;
//    private int remainingEnemyCount;
//    private int postMin = 10;
//    private int postMax = 230;

//    private Queue<GameObject> enemyPool = new Queue<GameObject>();
//    private int poolSize = 20;

//    private void Start()
//    {
//        remainingEnemyCount = maxEnemyCount;
//        InitializeEnemyPool();
//        UpdateEnemyCountText();
//    }

//    private void InitializeEnemyPool()
//    {
//        for (int i = 0; i < poolSize; i++)
//        {
//            GameObject enemy = Instantiate(enemyPrefab);
//            enemy.SetActive(false);
//            enemyPool.Enqueue(enemy);
//        }
//    }

//    public void StartRandomEnemy()
//    {
//        StartCoroutine(RandomEnemyCoroutine());
//    }

//    private IEnumerator RandomEnemyCoroutine()
//    {
//        while (enemyCount < maxEnemyCount)
//        {
//            posX = UnityEngine.Random.Range(postMin, postMax);
//            SpawnEnemy(new Vector3(posX, 0, posZ));
//            enemyCount++;
//            UpdateEnemyCountText();
//            yield return new WaitForSeconds(0.1f); // Sử dụng WaitForSeconds thay vì WaitForSecondsRealtime để tránh ảnh hưởng đến hiệu suất
//        }
//    }

//    private void SpawnEnemy(Vector3 position)
//    {
//        if (enemyPool.Count > 0)
//        {
//            GameObject enemy = enemyPool.Dequeue();
//            enemy.transform.position = position;
//            enemy.transform.rotation = Quaternion.identity;
//            enemy.SetActive(true);
//        }
//        else
//        {
//            Debug.LogWarning("Enemy pool is empty!");
//        }
//    }

//    public void EnemyDestroyed(GameObject enemy)
//    {
//        remainingEnemyCount--;
//        enemy.SetActive(false);
//        enemyPool.Enqueue(enemy);
//        UpdateEnemyCountText();

//        if (remainingEnemyCount == 0)
//        {
//            OnAllEnemiesDestroyed();
//        }
//    }

//    private void UpdateEnemyCountText()
//    {
//        if (enemyCountText != null)
//        {
//            enemyCountText.text = "" + remainingEnemyCount;
//        }
//    }

//    private void OnAllEnemiesDestroyed()
//    {
//        QuestManager.SubQuestNumber = 1;
//        quest01Finished.SetActive(true);
//    }
//}

