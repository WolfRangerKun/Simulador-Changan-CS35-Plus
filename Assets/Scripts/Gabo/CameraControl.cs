using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera cameraOrbital;
    public int speedkeyboard;
    public string mouseName = "Mouse X";
    public float cameraZoom, minCameraZoom;
    public bool zoomActive;

    public UnityEvent changeCamera, reverseChangeCamera;

    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            CameraOrbitalMovement(-speedkeyboard);
        }
        if (Input.GetKey(KeyCode.A))
        {
            CameraOrbitalMovement(speedkeyboard);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CameraOrbitalMouse(mouseName);
        }
        else
        {
            CameraOrbitalMouse("");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraZoom();
        }
    }
    public void CameraOrbitalMovement(int speed)
    {
        cameraOrbital.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.Value += speed * Time.deltaTime;
    }
    public void CameraOrbitalMouse(string MouseAxis)
    {
        cameraOrbital.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_InputAxisName = MouseAxis;
    }
    public void CameraZoom()
    {
        zoomActive = !zoomActive;

        if (zoomActive)
        {
            changeCamera?.Invoke();
        }
        else
        {
            if (!zoomActive)
            {
                reverseChangeCamera?.Invoke();
            }
        }
    }
}
