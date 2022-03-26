using System.Collections;
using TMPro;
using UnityEngine;


public class RaycastMovementDetection : MonoBehaviour
{
    ControlRoquerio cR;
    RaycastHit hitOne, hitTwo;
    public Transform izq, der;
    public TextMeshPro textInScene, contador;
    public LayerMask layerToAct;
    Color rayColorOne, rayColorTwo;
    int uwu;
    public bool win;
    bool lol = true;


    private void Awake()
    {
        cR = FindObjectOfType<ControlRoquerio>();
    }
    void Start()
    {
        uwu = 3;
        rayColorOne = Color.blue;
        rayColorTwo = Color.blue;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(izq.position, der.forward, out hitOne, Mathf.Infinity, layerToAct))
        {
            if (hitOne.collider.CompareTag("PartTag"))
            {
                rayColorOne = Color.green;
            }
            else
            {
                rayColorOne = Color.red;

            }
        }


        Debug.DrawRay(izq.position, der.forward * hitOne.distance, rayColorOne/*, Mathf.Infinity*/);

        if (Physics.Raycast(der.position, der.forward, out hitTwo, Mathf.Infinity, layerToAct))
        {
            if (hitTwo.collider.CompareTag("PartTag"))
            {
                rayColorTwo = Color.green;
            }
            else
            {
                rayColorTwo = Color.red;

            }
        }


        Debug.DrawRay(der.position, der.forward * hitTwo.distance, rayColorTwo/*, Mathf.Infinity*/);
        ///////////////////////////
        ///
        if (hitTwo.collider == true && hitOne.collider == true)
        {
            if (hitTwo.collider.CompareTag("PartTag") && hitOne.collider.CompareTag("PartTag") && lol)
            {
                //if (lol)
                {
                    textInScene.color = Color.green;
                    textInScene.text = "VasBien";

                    StartCoroutine(CuentaAtras());
                    lol = false;
                    print("uwu1");
                }

            }
            
        }
        else
        {
            if ((hitTwo.collider == false && hitOne.collider == false) || (hitTwo.collider == false && hitOne.collider == true) || (hitTwo.collider == true && hitOne.collider == false))
            {
                if (!lol)
                {
                    StopAllCoroutines();
                    textInScene.color = Color.red;
                    textInScene.text = "VasMal";
                    contador.text = "x";
                    uwu = 3;
                    lol = true;
                    print("uwu2");
                }
            }


        }

        if (win)
        {
            cR.StopAllCoroutines();
            StopAllCoroutines();
        }
    }



    IEnumerator CuentaAtras()
    {
        contador.text = uwu.ToString();
        yield return new WaitForSeconds(1);
        uwu--;
        contador.text = uwu.ToString();
        yield return new WaitForSeconds(1);
        uwu--;
        contador.text = uwu.ToString();
        yield return new WaitForSeconds(1);
        uwu--;
        contador.text = uwu.ToString();
        win = true;
        yield break;
    }


}
