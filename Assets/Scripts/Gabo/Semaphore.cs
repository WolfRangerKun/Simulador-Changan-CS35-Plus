using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaphore : MonoBehaviour
{
    public GameObject button1, button2, button3;
    public bool forward, right, left;

    private void Start()
    {

    }
    public void ActiveButtons()
    {
        if (forward)
        {
            button1.SetActive(true);
        }
        if (right)
        {
            button2.SetActive(true);
        }
        if (left)
        {
            button3.SetActive(true);
        }
    }

    //public void DesactiveButtons()
    //{
    //    button1.SetActive(false);
    //    button2.SetActive(false);
    //    button3.SetActive(false);
    //}
    
}
