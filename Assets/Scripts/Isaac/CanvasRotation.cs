using Cinemachine;
using System.Collections;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    public GameObject informationCanvas;
    bool zoomInPart;
    void Update()
    {
        transform.forward = Camera.main.transform.forward;

        if (zoomInPart && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraChange();
        }
    }


    public void CameraChange()
    {
        zoomInPart = !zoomInPart;
        if (zoomInPart)
        {
            CinemachineVirtualCamera cameraMain = GameObject.Find("CM Principal").GetComponent<CinemachineVirtualCamera>();
            CinemachineVirtualCamera cameraToGo = gameObject.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
            GameObject button = gameObject.transform.GetChild(0).gameObject;

            print(cameraToGo.gameObject.name);

            button.SetActive(false);
            StartCoroutine(SpawnInfo());

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
            CinemachineVirtualCamera cameraMain = GameObject.Find("CM Principal").GetComponent<CinemachineVirtualCamera>();
            CinemachineVirtualCamera cameraToGo = gameObject.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
            GameObject button = gameObject.transform.GetChild(0).gameObject;

            print(cameraToGo.gameObject.name);
            informationCanvas.SetActive(false);


            button.SetActive(true);
            cameraToGo.Priority = -1;
            cameraMain.Priority = 99;
        }

    }
}
