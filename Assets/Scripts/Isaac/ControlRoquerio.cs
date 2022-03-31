using System.Collections;
using UnityEngine;

public class ControlRoquerio : MonoBehaviour
{
    public static ControlRoquerio instance;
    public float strengUsed, strengRandom;
    int randomNumber;
    Rigidbody rb;

    RaycastMovementDetection rMD; 
    
    void Awake()
    {
        instance = this;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rMD = FindObjectOfType<RaycastMovementDetection>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * strengUsed, ForceMode.Acceleration);
        }


        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * strengUsed, ForceMode.Acceleration);
        }

        //if (Input.GetKeyDown(KeyCode.Space) && rMD.win == false)
        //{
        //    StartCoroutine(GetNumber());
        //    StartCoroutine(RandomForce());
        //}
    }

    private void FixedUpdate()
    {
        //randomNumber = Random.Range(0, 10);
        if (RaycastMovementDetection.instance.win == true)
        {
            StopAllCoroutines();
        }
    }


    public IEnumerator RandomForce()
    {
        while (true)
        {
            if (randomNumber > 5)
            {

                //print("sumandoFuerzaIZQUIERDA");
                rb.AddForce(Vector3.left * strengRandom, ForceMode.Impulse);
                print(randomNumber);
                yield return new WaitForSeconds(Random.Range(2, 4));


            }
            else
            {

                //print("sumandoFuerzaDERECHA");
                rb.AddForce(Vector3.right * strengRandom, ForceMode.Impulse);

                print(randomNumber);
                yield return new WaitForSeconds(Random.Range(2, 4));

            }
        }

    }

     public IEnumerator GetNumber()
    {
        while (true)
        {
            randomNumber = Random.Range(0, 10);
            yield return new WaitForSeconds(Random.Range(5, 8));

        }

    }
}
