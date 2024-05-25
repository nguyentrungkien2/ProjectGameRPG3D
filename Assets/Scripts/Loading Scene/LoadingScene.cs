using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScene;
    public Image fillValueLoading;
    public TMP_Text percentLoading;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        loadingScene.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            fillValueLoading.fillAmount = progressValue;
            percentLoading.text = (progressValue * 100).ToString("F0") + "%";
            yield return null;
        }

        if (loadingScene != null)
        {
            loadingScene.SetActive(false);
        }
    }
}


