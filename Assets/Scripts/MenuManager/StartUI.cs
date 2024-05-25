using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartUI : MonoBehaviour
{
    public bool alwaysDisplayMouse;
    public GameObject pauseCanvas;
    public GameObject optionsCanvas;
    public GameObject controlsCanvas;
    public GameObject audioCanvas;

    protected bool m_InPause;
    protected PlayableDirector[] m_Directors;

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
    }


}
