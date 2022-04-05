using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyudaSubidaBajada : MonoBehaviour
{
    public GameObject simbolo;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            simbolo.SetActive(true);
        }
        else
        {
            simbolo.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            simbolo.SetActive(false);
        }
    }
}
