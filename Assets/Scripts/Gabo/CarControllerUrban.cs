using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarControllerUrban : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;
    public Vector3 direction;
    public int directionNumer;
    public float directionRay;
    public LayerMask trafficLight;
    public bool move;
    public UnityEvent canvasShow, canvasOut;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            AutomaticDirection();
            DetectionSemaforo();
            move = true;
        }


    }
    public void AutomaticConduction()
    {
        //rb.AddForce(direction * speed * Time.deltaTime);
        //rb.velocity = direction * speed * Time.deltaTime;
    }

    public void AutomaticDirection()
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
        direction = direction * directionRay;
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.red, directionRay);
        if (Physics.Raycast(transform.position, direction, out hit, directionRay, trafficLight) && move)
        {
            directionNumer = 0;
            direction = direction.normalized;
            canvasShow?.Invoke();
            move = false;
        }
        else
        {
            direction = direction.normalized;
            canvasOut?.Invoke();
            move = true;
        }
    }
}
