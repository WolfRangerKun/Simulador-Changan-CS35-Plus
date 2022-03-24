using System.Collections;
using UnityEngine;

public class ControlRoquerio : MonoBehaviour
{
    public float streng;
    int randomNumber;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * streng, ForceMode.Acceleration);
        }


        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * streng, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetNumber());
            StartCoroutine(RandomForce());
        }
    }

    private void FixedUpdate()
    {
        //randomNumber = Random.Range(0, 10);
    }


    IEnumerator RandomForce()
    {
        while (true)
        {
            if (randomNumber > 5)
            {

                print("sumandoFuerzaIZQUIERDA");
                print(randomNumber);
                yield return new WaitForSeconds(Random.Range(2, 4));


            }
            else
            {

                print("sumandoFuerzaDERECHA");
                print(randomNumber);
                yield return new WaitForSeconds(Random.Range(2, 4));

            }
        }

    }

    IEnumerator GetNumber()
    {
        while (true)
        {
            randomNumber = Random.Range(0, 10);
            yield return new WaitForSeconds(Random.Range(5, 8));

        }

    }
}
