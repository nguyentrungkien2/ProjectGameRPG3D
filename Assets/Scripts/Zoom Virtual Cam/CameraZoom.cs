using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] [Range(0f,10f)]  private float defaultValueDistance = 6.0f;
    [SerializeField] [Range(0f,10f)] private float minValueDistance = 1.0f;
    [SerializeField] [Range(0f,10f)] private float maxValueDistance = 6.0f;

    [SerializeField][Range(0f, 10f)] private float smoothing = 4.0f;
    [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 1.0f;

    private CinemachineFramingTransposer framingTransposer;
    private CinemachineInputProvider inputProvider;

    private float currentTargetDistance;
    private float zoomValue;
    private float currentDistace;
    private float lerpedZoomValue;

    private void Awake()
    {
        framingTransposer=GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        inputProvider = GetComponent<CinemachineInputProvider>();
        currentTargetDistance = defaultValueDistance;
    }
    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;
        currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue, minValueDistance, maxValueDistance);

        currentDistace = framingTransposer.m_CameraDistance;
        if(currentDistace == currentTargetDistance)
        {
            return;
        }
        lerpedZoomValue=Mathf.Lerp(currentDistace, currentTargetDistance, smoothing*Time.deltaTime);
        framingTransposer.m_CameraDistance = lerpedZoomValue;
    }
}
