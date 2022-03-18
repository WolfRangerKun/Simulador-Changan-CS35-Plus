using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera cameraOrbital;
    public int speedkeyboard;
    public string mouseName = "Mouse X";
    public float cameraZoom;
    public float minCameraZoom;

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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            CameraOrbitalMouse(mouseName);
        }
        else
        {
            CameraOrbitalMouse("");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
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
    //public void CameraZoom()
    //{
    //    if(cameraOrbital.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.z >= minCameraZoom)
    //    {
    //        cameraOrbital.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.z += cameraZoom;
    //    }
    //}
}
