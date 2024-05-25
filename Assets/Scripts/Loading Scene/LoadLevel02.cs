using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel02 : MonoBehaviour
{
    [SerializeField] private GameObject imgFinishedLevel01;
    private TimeManager timeManager;
    private bool isLevelCompleted = false;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isLevelCompleted)
        {
            if (timeManager != null)
            {
                timeManager.PauseTime();
                timeManager.SetGameFinished(); // Đặt trạng thái của trò chơi khi màn chơi hoàn thành
            }
            imgFinishedLevel01.gameObject.SetActive(true);
            isLevelCompleted = true; // Đánh dấu rằng màn chơi đã hoàn thành
        }
    }
}
