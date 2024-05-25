using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest01 : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject imgQuest01;
    public GameObject imgQuest02;
    public GameObject UIQuest01;
    public GameObject UIQuest02;
    public GameObject ThePlayer;

    void OnTriggerStay(Collider other)
    {
        float TheDistance = PlayerCasting.DistanceFromTarget;
        if (TheDistance <= 24)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        

            if (Input.GetKeyDown(KeyCode.E))
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);

                // Kiểm tra xem UIQuest01 có active hay không
                if (imgQuest01.activeSelf == false)
                {
                    UIQuest02.SetActive(true);
                }
                if (imgQuest02.activeSelf == false)
                {
                    UIQuest01.SetActive(true);
                }
                ThePlayer.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
