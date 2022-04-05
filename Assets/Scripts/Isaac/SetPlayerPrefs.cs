using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        PlayerPrefs.SetInt("CargarMenu 1", 1);

        PlayerPrefs.SetInt("CargarMenu 2", 0);
        PlayerPrefs.SetInt("CargarMenu 3", 0);
        PlayerPrefs.SetInt("CargarMenu 4", 0);

    }


}
