using TMPro;
using UnityEngine;


public class MiniGameCanvas : MonoBehaviour
{
    public Transform raycastOrigin;
    public Rigidbody2D cs35;
    public float velocity;
    public TextMeshPro distanciaLive;
    RaycastHit2D rHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    private void FixedUpdate()
    {
        rHit = Physics2D.Raycast(raycastOrigin.position, Vector2.up);

        if (rHit.collider != null)
        {
            float distance = (rHit.distance * 100);
            int distanceRound = Mathf.RoundToInt(distance);
            distanciaLive.text = distanceRound.ToString() + "mts";
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {

            other.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {
            other.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


}
