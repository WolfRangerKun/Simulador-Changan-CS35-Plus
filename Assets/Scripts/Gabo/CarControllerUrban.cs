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
    public Semaphore semaphore;
    //public UnityEvent canvasShow, canvasOut;
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
        AngleConduction();
    }
    public void AngleConduction()
    {
        if(transform.rotation.x < -15)
        {
            rb.velocity = -direction * 100 * Time.deltaTime;
        }
    }

    public void AutomaticDirection()
    {
        switch (directionNumer)
        {
            case 1:
                Debug.Log("hacia adelante");
                direction = transform.TransformDirection(Vector3.forward);
                rb.velocity = direction * speed * Time.deltaTime;
                //rb.AddForce(direction * speed * Time.deltaTime);
                
                break;
            case 2:
                Debug.Log("hacia la derecha");
                direction = Vector3.right;
                rb.velocity = direction * speed * Time.deltaTime;
                //rb.AddForce(direction * speed * Time.deltaTime);
                break;
            case 3:
                Debug.Log("hacia la izquierda");
                direction = Vector3.left;
                rb.velocity = direction * speed * Time.deltaTime;
                //rb.AddForce(direction * speed * Time.deltaTime);
                break;
        }
    }

    public void ChangeDirection(int changeNumer)
    {
        directionNumer = changeNumer;
    }

    public void ChangeOritacion(int angle)
    {
        transform.eulerAngles = new Vector3(0, angle, 0);
        
    }

    public void DetectionSemaforo()
    {
        direction = direction * directionRay;
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.red, directionRay);
        if (Physics.Raycast(transform.position, direction, out hit, directionRay, trafficLight) && move)
        {
            //hit.collider.GetComponent<BoxCollider>();
            move = false;
            directionNumer = 0;
            direction = direction.normalized;
            semaphore = hit.collider.GetComponent<Semaphore>();
            semaphore.ActiveButtons();
            hit.collider.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            direction = direction.normalized;
            move = true;
        }
    }
}
