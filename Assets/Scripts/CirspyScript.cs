using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirspyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpHeight;
    public float moveSpeed;
    private bool isJumping = false;


    void Start()
    {
        CapsuleCollider2D isGround = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * moveSpeed;  // deltaTime = Einheiten pro Sekunde 
                                                                                      // ohne deltaTime = Einheiten pro Frame

        if (Input.GetMouseButton(0) && !isJumping)
        {
            myRigidbody.velocity = Vector2.up * jumpHeight;
            isJumping = true;
        }
        
        if(moveSpeed < 8)
        {
            Debug.Log("Quit triggered");
            Application.Quit();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            isJumping = false;     
        }

        if (other.CompareTag("spawnGround"))
        {
            FindObjectOfType<groundSpawner>().SpawnGround();
        }

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with Obstacle");

            Destroy(other.gameObject);
            moveSpeed --;
        }

        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            moveSpeed ++;
        }

        if (other.CompareTag("Rabbit"))
        {
            Debug.Log("Quit triggered");
            Application.Quit();
        }
           
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("spawnGround"))
        {
            Destroy(other.gameObject, 2);
        }
    }
}
