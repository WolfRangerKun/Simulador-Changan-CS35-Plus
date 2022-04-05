using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiganrDialogommenu : MonoBehaviour
{
    public GameObject dia1, dia2, dia3, dia4;
    void Awake()
    {
        if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 0 && PlayerPrefs.GetInt("CargarMenu 3") == 0 && PlayerPrefs.GetInt("CargarMenu 4") == 0)
        {
            dia1.SetActive(true);
            dia2.SetActive(false);
            dia3.SetActive(false);
            dia4.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 0 && PlayerPrefs.GetInt("CargarMenu 4") == 0)
        {
            dia1.SetActive(false);
            dia2.SetActive(true);
            dia3.SetActive(false);
            dia4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 1 && PlayerPrefs.GetInt("CargarMenu 4") == 0)
        {
            dia1.SetActive(false);
            dia2.SetActive(false);
            dia3.SetActive(true);
            dia4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 1 && PlayerPrefs.GetInt("CargarMenu 4") == 1)
        {
            dia1.SetActive(false);
            dia2.SetActive(false);
            dia3.SetActive(false);
            dia4.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
