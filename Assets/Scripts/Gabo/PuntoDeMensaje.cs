using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuntoDeMensaje : MonoBehaviour
{
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagerGabo.instance.AddIntContador();
            Punto1();
        }
    }
    public void Punto1()
    {
        onTrigger?.Invoke();
    }
}
