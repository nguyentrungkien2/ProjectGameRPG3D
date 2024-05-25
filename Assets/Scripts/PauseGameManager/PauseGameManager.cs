using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPauseGame;
    [SerializeField] private GameObject loadingUI;
    private float loadingDelay = 0.5f; // Độ trễ trước khi tải lại scene (thời gian tính bằng giây)
    private TimeManager timeManager;
    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }
    private void Update()
    {
        TurnOnPauseGameBox();
    }

    public void TurnOnPauseGameBox()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timeManager.PauseTime();
            mainPauseGame.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        loadingUI.SetActive(true);
        StartCoroutine(LoadLevelWithDelay());
    }

    IEnumerator LoadLevelWithDelay()
    {
        // Chờ một khoảng thời gian nhỏ trước khi tải lại scene
        yield return new WaitForSeconds(loadingDelay);

        // Tải lại scene sau khi chờ đợi
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
