using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MiniGameCanvas : MonoBehaviour
{
    public static MiniGameCanvas instance;
    public List<Dialogue> limiteLateral;
    public List<Dialogue> limiteChoque;

    public Transform raycastOrigin;
    public GameObject autoFrente;
    public SpriteRenderer camino;
    public Vector2 autoFrenteOriginalPOs;

    public Rigidbody2D cs35;
    public float velocity;
    public TextMeshPro distanciaLive;
    public bool canUse;
    RaycastHit2D rHit;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //autoFrenteOriginalPOs = autoFrente.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            if (Input.GetKey(KeyCode.A))
            {
                cs35.AddForce(Vector2.left * velocity, ForceMode2D.Force);
            }


            if (Input.GetKey(KeyCode.D))
            {
                cs35.AddForce(Vector2.right * velocity, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.W))
            {
                cs35.AddForce(Vector2.up * velocity, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.S))
            {
                cs35.AddForce(Vector2.down * velocity, ForceMode2D.Force);
            }
        }

       
    }
    bool reproduce = true;

    private void FixedUpdate()
    {
        rHit = Physics2D.Raycast(raycastOrigin.position, Vector2.up);

        if (rHit.collider != null)
        {
            float distance = (rHit.distance * 100);
            int distanceRound = Mathf.RoundToInt(distance);
            distanciaLive.text = distanceRound.ToString() + "mts";

            if (distanceRound <= 30 && reproduce)
            {
                DialogueManager.intance.index = 0;
                DialogueManager.intance.dialogos = limiteChoque;

                DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
                // idealmente poner una corrutina que haga que el auto se aleje
                reproduce = false;
            }

            if (DialogueManager.intance.index == 0 && distanceRound > 40)
            {
                reproduce = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {
            camino.color = Color.red;

            if (DialogueManager.intance.dialogoPanel.position != DialogueManager.intance.puntoGuia.position)
            {
                DialogueManager.intance.index = 0;
                DialogueManager.intance.dialogos = limiteLateral;
                DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {
            camino.color = Color.white;
            DialogueManager.intance.HideDialogo();

        }
    }

    float down = -2;
    float up = 2;
    public IEnumerator RamdomAutoX()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(Random.Range(6, 10));

            if (autoFrente.transform.position.y >= autoFrenteOriginalPOs.y + 10)
            {
                up = -2;
            }
            else
            {
                up = 2;
            }

            if (autoFrente.transform.position.y <= autoFrenteOriginalPOs.y - 20)
            {
                down = 2;
            }
            else
            {
                down = -2;
            }

            autoFrente.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(down, up), ForceMode2D.Force);
        }

    }

}
