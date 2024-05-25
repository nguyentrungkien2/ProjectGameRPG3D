using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest01Button : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject UIQuest;
    public TMP_Text ActiveQuestText;
    public TMP_Text Objective01Text;
    public TMP_Text Objective02Text;
    public TMP_Text Objective03Text;
    public GameObject BorderQuest;

    public void AcceptQuest()
    {
        QuestManager.SubQuestNumber = 1;
        ThePlayer.SetActive(true);
        UIQuest.SetActive(false);
        StartCoroutine(SetQuestUI());
    }

    IEnumerator SetQuestUI()
    {
        BorderQuest.SetActive(true);
        ActiveQuestText.text = "Nhiệm vụ 01:";
        Objective01Text.text = "Tương tác với các NPC thực hiện nhiệm vụ";
        Objective02Text.text = "đến gặp phù thuỷ cô đơn";
        Objective03Text.text = "Nhận vũ khí và vượt qua thử thách";
        QuestManager.ActiveQuestNumber = 1;
        yield return new WaitForSeconds(0.5f);
        ActiveQuestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        Objective01Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        Objective02Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        Objective03Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        ActiveQuestText.gameObject.SetActive(false);
        Objective01Text.gameObject.SetActive(false);
        Objective02Text.gameObject.SetActive(false);
        Objective03Text.gameObject.SetActive(false);
        BorderQuest.SetActive(false);
    }

    public void DeclineQuest()
    {
        ThePlayer.SetActive(true);
        UIQuest.SetActive(false);
    }
}
