using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class EventBearDie : MonoBehaviour
{
    [SerializeField] private GameObject NPCMagician;
    [SerializeField] private GameObject texBoxFinishedQuest01;

    [SerializeField] private GameObject heartHpPlayer;  
    [SerializeField] private GameObject turnOffQuest01;
    [SerializeField] private GameObject turnOnQuest02;


    private void Update()
    {
       StartCoroutine(BearDie());
    }
    IEnumerator BearDie()
    {
        texBoxFinishedQuest01.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        turnOffQuest01.gameObject.SetActive(false);
        turnOnQuest02.gameObject.SetActive(true);
        gameObject.SetActive(false);
        heartHpPlayer.gameObject.SetActive(true);
        texBoxFinishedQuest01.gameObject.SetActive(false);
        Destroy(NPCMagician.gameObject);
        QuestManager.SubQuestNumber = 2;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }    
}
