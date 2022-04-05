using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerGabo : MonoBehaviour
{
    public static GameManagerGabo instance;
    public  int contadorPunto;
    public bool oneI, dosI;

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

    public void OnEdd()
    {
        oneI = true;
    }
    public void DosEdd()
    {
        dosI = true;
    }

    public void DosEddss()
    {
        dosI = false;
    }

    public void AddIntContador()
    {
        contadorPunto++;
    }
}
