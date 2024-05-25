using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionSwordAndPlayer : MonoBehaviour
{
    public GameObject weponSword;
    public void EnableWeponSkeletonCollider(int isEnable)
    {
        //kiểm tra player có cầm kiếm không
        if (weponSword != null)
        {
            var col = weponSword.GetComponent<Collider>();
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
