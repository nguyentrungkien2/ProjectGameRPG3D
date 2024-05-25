using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest02Button : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject UIQuest;
    public TMP_Text ActiveQuestText;
    public TMP_Text Objective01Text;
    public TMP_Text Objective02Text;
    public GameObject BorderQuest;
    public GameObject pointCheckdisplayDragon;

    public void AcceptQuest()
    {
        QuestManager.SubQuestNumber = 3;
        ThePlayer.SetActive(true);
        UIQuest.SetActive(false);   
        StartCoroutine(SetQuestUI());
    }

    IEnumerator SetQuestUI()
    {
        BorderQuest.SetActive(true);
        ActiveQuestText.text = "Nhiệm vụ 02:";
        Objective01Text.text = "Đến hang rồng tiêu diệt Rồng Sepai";
        Objective02Text.text = "Trở về thị trấn";
        QuestManager.ActiveQuestNumber = 1;
        yield return new WaitForSeconds(0.5f);
        ActiveQuestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        Objective01Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        Objective02Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        ActiveQuestText.gameObject.SetActive(false);
        Objective01Text.gameObject.SetActive(false);
        Objective02Text.gameObject.SetActive(false);
        pointCheckdisplayDragon.gameObject.SetActive(true);
        BorderQuest.SetActive(false);
    }

    public void DeclineQuest()
    {
        ThePlayer.SetActive(true);
        UIQuest.SetActive(false);
    }
}
