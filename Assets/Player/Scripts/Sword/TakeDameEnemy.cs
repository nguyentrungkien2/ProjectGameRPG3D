using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDameEnemy : MonoBehaviour
{
    public TakeDameEnemyManager takeDameEnemy;
    public DragonTakeDameEnemyManager dragonTakeDameEnemy;
    public SkeletonTakeDameManager skeletonTakeDameEnemy;
    public HealthBarBossManager healthBarBossManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyManager = other.GetComponent<TakeDameEnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.TakeDame(1);
            }
        }

        if (other.CompareTag("EnemyDragon"))
        {
            var dragonManager = other.GetComponent<DragonTakeDameEnemyManager>();
            if (dragonManager != null)
            {
                dragonManager.TakeDame(1);
            }
        }

        if (other.CompareTag("Skeleton Enemy"))
        {
            var skeletonManager = other.GetComponent<SkeletonTakeDameManager>();
            if (skeletonManager != null)
            {
                skeletonManager.TakeDame(1);
            }
        }

        if (other.CompareTag("Boss"))
        {
            var bossManager = other.GetComponent<HealthBarBossManager>();
            if (bossManager != null)
            {
                bossManager.TakeDame(1);
            }
        }
    }
}
