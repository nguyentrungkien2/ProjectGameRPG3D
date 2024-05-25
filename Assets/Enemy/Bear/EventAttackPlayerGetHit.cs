using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAttackPlayerGetHit : MonoBehaviour
{
    public GameObject objectAttack01;
    public GameObject objectAttack02;
    public void EnableBearCollider(int isEnable)
    {
        var col = objectAttack01.GetComponent<Collider>();
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
    public void EnableBearCollider02(int isEnable)
    {

        var col = objectAttack02.GetComponent<Collider>();
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
