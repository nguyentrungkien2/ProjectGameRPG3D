
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scence01 : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private GameObject Camera3;
    [SerializeField] private GameObject FadeOut;
    [SerializeField] private GameObject FadeIn;
    [SerializeField] private GameObject ThePlayer;
    [SerializeField] private Button skipButton;
    [SerializeField] private GameObject StoryGame;

    private Coroutine cutSceneCoroutine;
    private bool isSkipping = false;

    [SerializeField] private Camera[] cameraToDelete;
    void Awake()
    {
        skipButton.onClick.AddListener(SkipCutScene);
        cutSceneCoroutine = StartCoroutine(CutSceneStart());
    }

    IEnumerator CutSceneStart()
    {
        if (!isSkipping)
        {
            FadeOut.SetActive(true);
            FadeIn.SetActive(false);
            yield return new WaitForSeconds(1);
            StoryGame.gameObject.SetActive(true);
            FadeOut.SetActive(false);
            yield return new WaitForSeconds(8);
            StoryGame.gameObject.SetActive(false);
            Camera1.SetActive(true);
            yield return new WaitForSeconds(5);
            Camera2.SetActive(true);
            Camera1.SetActive(false);
            FadeIn.SetActive(false);
            yield return new WaitForSeconds(9);
            Camera3.SetActive(true);
            Camera2.SetActive(false);
            yield return new WaitForSeconds(4);
            FadeOut.SetActive(true);
            yield return new WaitForSeconds(1);

            ThePlayer.SetActive(true);
            mainCamera.SetActive(true);
            DeleteCam();
            FadeIn.SetActive(true);
            FadeOut.SetActive(false);
            Camera3.SetActive(false);
            Destroy(skipButton.gameObject);
        }
    }

    public void SkipCutScene()
    {
        StopCoroutine(cutSceneCoroutine);

        ThePlayer.SetActive(true);
        mainCamera.SetActive(true);
        FadeIn.SetActive(true);
        FadeOut.SetActive(false);

        DeleteCam();
        StoryGame.gameObject.SetActive(false);
        Destroy(skipButton.gameObject);
    }

    public void DeleteCam()
    {
        foreach(Camera cam in cameraToDelete)
        {
            Destroy(cam.gameObject);
        }    
    }    
}
