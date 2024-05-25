using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTakeDamePlayer : MonoBehaviour
{
    public GameObject bossLeftHand;
    public GameObject bossRightHand;    
    public void EnableLeftHandBossCollider(int isEnable)
    {
        //kiểm tra player có cầm kiếm không
        if (bossLeftHand != null)
        {
            var col = bossLeftHand.GetComponent<Collider>();
            //kiểm tra kiếm bật colli không
            if (col != null)
            {
                if (isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }
    public void EnableRightHandBossCollider(int isEnable)
    {
        //kiểm tra player có cầm kiếm không
        if (bossRightHand != null)
        {
            var col = bossRightHand.GetComponent<Collider>();
            //kiểm tra kiếm bật colli không
            if (col != null)
            {
                if (isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }
}
