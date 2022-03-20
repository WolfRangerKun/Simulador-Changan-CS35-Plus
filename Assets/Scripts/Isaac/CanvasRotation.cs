using Cinemachine;
using System.Collections;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    public GameObject informationCanvas;
    bool zoomInPart;
    public bool isThisButton;
    GameObject[] parts;
    GameObject[] mainsCameras;


    CinemachineVirtualCamera cameraMain;
    private void Start()
    {
        parts = GameObject.FindGameObjectsWithTag("PartTag");
        mainsCameras = GameObject.FindGameObjectsWithTag("MainsCamerasCM");
    }
    void Update()
    {

        if (zoomInPart && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraChange();
        }
    }

    private void FixedUpdate()
    {
        transform.forward = Camera.main.transform.forward;

    }


    public void CameraChange()
    {
        zoomInPart = !zoomInPart;
        if (zoomInPart)
        {
            foreach (GameObject camera in mainsCameras)
            {
                if (camera.GetComponent<CameraControl>())
                {
                    camera.GetComponent<CameraControl>().canUse = false;
                }
            }

            isThisButton = true;

            foreach (GameObject buttom in parts)
            {
                if (buttom.transform.GetChild(0).GetComponent<CanvasRotation>().isThisButton == false)
                {
                    buttom.gameObject.SetActive(false);
                }
            }


            foreach (GameObject camera in mainsCameras)
            {
                if (camera.GetComponent<CinemachineVirtualCamera>().Priority == 1)
                {
                    cameraMain =  camera.GetComponent<CinemachineVirtualCamera>();
                }
            }

            //CinemachineVirtualCamera cameraMain = GameObject.Find("CM Principal").GetComponent<CinemachineVirtualCamera>();


            CinemachineVirtualCamera cameraToGo = gameObject.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
            GameObject button = gameObject.transform.GetChild(0).gameObject;



            print(cameraToGo.gameObject.name);

            button.SetActive(false);
            StartCoroutine(SpawnInfo());
            print(cameraMain.gameObject.name);

            cameraMain.Priority = -1;
            cameraToGo.Priority = 99;



            IEnumerator SpawnInfo()
            {
                yield return new WaitForSeconds(1);
                informationCanvas.SetActive(true);

                print("ola");
            }
        }
        else
        {
            foreach (GameObject camera in mainsCameras)
            {
                if (camera.GetComponent<CameraControl>())
                {
                    camera.GetComponent<CameraControl>().canUse = true;
                }
            }

            foreach (GameObject buttom in parts)
            {
                if (buttom.transform.GetChild(0).GetComponent<CanvasRotation>().isThisButton == false)
                {
                    buttom.gameObject.SetActive(true);
                }
            }

            isThisButton = false;



            //CinemachineVirtualCamera cameraMain = GameObject.Find("CM Principal").GetComponent<CinemachineVirtualCamera>();
            CinemachineVirtualCamera cameraToGo = gameObject.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
            GameObject button = gameObject.transform.GetChild(0).gameObject;

            print(cameraToGo.gameObject.name);
            informationCanvas.SetActive(false);


            button.SetActive(true);
            cameraToGo.Priority = -1;
            print(cameraMain.gameObject.name);

            cameraMain.Priority = 1;
            cameraMain = null;
        }

    }
}
