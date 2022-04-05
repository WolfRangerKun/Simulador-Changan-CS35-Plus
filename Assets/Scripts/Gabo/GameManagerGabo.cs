using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerGabo : MonoBehaviour
{
    public static GameManagerGabo instance;
    public  int contadorPunto;


    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(contadorPunto == 1)
        {

        }
        if(contadorPunto == 2)
        {

        }
    }

    public void AddIntContador()
    {
        contadorPunto++;
    }
}
