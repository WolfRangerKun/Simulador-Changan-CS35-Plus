using Cinemachine;
using System.Collections;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    public GameObject informationCanvas;
    bool zoomInPart;
    public bool isThisButton;
    GameObject[] parts;

    private void Start()
    {
        parts = GameObject.FindGameObjectsWithTag("PartTag");

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
            isThisButton = true;

            foreach (GameObject buttom in parts)
            {
                if (buttom.transform.GetChild(0).GetComponent<CanvasRotation>().isThisButton == false)
                {
                    buttom.gameObject.SetActive(false);
                }
            }
            

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
            foreach (GameObject buttom in parts)
            {
                if (buttom.transform.GetChild(0).GetComponent<CanvasRotation>().isThisButton == false)
                {
                    buttom.gameObject.SetActive(true);
                }
            }

            isThisButton = false;

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
