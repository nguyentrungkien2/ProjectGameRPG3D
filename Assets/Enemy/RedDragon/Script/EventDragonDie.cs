using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventDragonDie : MonoBehaviour
{
    public GameObject displayEntrace;
    public GameObject flashSwordDisplay;
    //boxtext player
    [SerializeField] private GameObject textBoxPLayer;
    [SerializeField] private GameObject descriptionPLayer01;
    [SerializeField] private GameObject descriptionPLayer02;
    [SerializeField] private GameObject descriptionPLayer03;
    
    //boxtext dragon
    [SerializeField] private GameObject textBoxDragon;
    [SerializeField] private GameObject descriptionDragon01;
    [SerializeField] private GameObject descriptionDragon02;


    //event completed
    private bool eventTriggered = false;
    private bool eventCompleted = false;

    private void Update()
    {
        // Kiểm tra nếu sự kiện chưa được kích hoạt và chưa hoàn thành
        if (!eventTriggered && !eventCompleted)
        {
            StartCoroutine(EventDieDragon());
            eventTriggered = true; // Đặt biến cờ là true để ngăn chặn sự kiện từ việc chạy lại
        }
    }

    private IEnumerator EventDieDragon()
    {
        // Lời khởi đầu của Coroutine

        yield return new WaitForSecondsRealtime(2);

        // Phần logic hiển thị tin nhắn
        //player 01
        textBoxPLayer.gameObject.SetActive(true);
        descriptionPLayer01.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(6);

        //dragon 01
        descriptionPLayer01.gameObject.SetActive(false);
        textBoxPLayer.gameObject.SetActive(false);
        textBoxDragon.gameObject.SetActive(true);
        descriptionDragon01.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8);

        //player 02
        descriptionDragon01.gameObject.SetActive(false);
        textBoxDragon.gameObject.SetActive(false);
        textBoxPLayer.gameObject.SetActive(true);
        descriptionPLayer02.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8);

        //dragon 02
        descriptionPLayer02.gameObject.SetActive(false);
        textBoxDragon.gameObject.SetActive(true);
        textBoxPLayer.gameObject.SetActive(false);
        descriptionDragon02.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(12);

        //player 03
        textBoxDragon.gameObject.SetActive(false);
        textBoxPLayer.gameObject.SetActive(true);
        descriptionPLayer03.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(6);


        textBoxPLayer.gameObject.SetActive(false);
        //displayEntrace.gameObject.SetActive(true);
        flashSwordDisplay.gameObject.SetActive(true);
        QuestManager.SubQuestNumber = 4;
        eventCompleted = true;
    }
}
