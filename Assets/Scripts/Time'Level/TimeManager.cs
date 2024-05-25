using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TMP_Text timeText; // Tham chiếu đến đối tượng Text để hiển thị thời gian

    private float startTime;
    private float elapsedTime;
    private bool isRunning;
    private bool isGameFinished = false; // Biến kiểm tra trạng thái của trò chơi

    private bool isPaused = false;
    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        elapsedTime = Time.time - startTime;
        DisplayTime(elapsedTime);
    }

    private void Update()
    {
        if (isRunning && !isGameFinished) // Kiểm tra trạng thái của trò chơi trước khi cập nhật thời gian
        {
            float currentTime = Time.time - startTime;
            DisplayTime(currentTime);
        }
    }
    private void DisplayTime(float time)
    {
        string minutes = ((int)time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timeText.text = "Thời gian hoàn thành màn chơi: " + minutes + ":" + seconds;
    }

    // Thêm phương thức này để đặt trạng thái của trò chơi khi màn chơi hoàn thành
    public void SetGameFinished()
    {
        isGameFinished = true;
    }

    public void PauseTime()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeTime();
        }
        else
        {
            PauseTime();
        }
    }
}


