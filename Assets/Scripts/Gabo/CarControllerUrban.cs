using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerUrban : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;
    public Vector3 direction;
    public int directionNumer;
    public float directionRay;
    public LayerMask trafficLight;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionNumer = 1;
    }

    public void Update()
    {
        AutomaticConduction();
        DetectionSemaforo();
    }

    public void AutomaticConduction()
    {
        switch (directionNumer)
        {
            case 1:
                Debug.Log("hacia adelante");
                direction = Vector3.forward;
                rb.velocity = direction * speed * Time.deltaTime;
                break;
            case 2:
                Debug.Log("hacia la derecha");
                direction = Vector3.right;
                rb.velocity = direction * speed * Time.deltaTime;
                break;
            case 3:
                Debug.Log("hacia la izquierda");
                direction = Vector3.left;
                rb.velocity = direction * speed * Time.deltaTime;
                break;
        }
    }

    public void ChangeDirection(int changeNumer)
    {
        directionNumer = changeNumer;
    }

    public void DetectionSemaforo()
    {
        RaycastHit hit;
        //Debug.DrawLine()
        Physics.Raycast(transform.position, direction, out hit, directionRay, trafficLight);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, direction);
    //}
}
