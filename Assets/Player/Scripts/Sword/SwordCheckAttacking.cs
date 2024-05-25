using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheckAttacking : MonoBehaviour
{
    public GameObject weponSword;
    public GameObject weponSword2;
    public void EnableWeponCollider(int isEnable)
    {
        //kiểm tra player có cầm kiếm không
        if(weponSword != null)
        {
            var col = weponSword.GetComponent<Collider>();
            //kiểm tra kiếm bật colli không
            if(col!=null )
            {
                if(isEnable == 1)
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
    public void EnableWepon02Collider(int isEnable)
    {
        //kiểm tra player có cầm kiếm 02 không
        if (weponSword2 != null)
        {
            var col = weponSword2.GetComponent<Collider>();
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
