using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirspyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpHeight;
    public float moveSpeed;
    private bool isJumping = false;
    public Animator animator;

    [SerializeField] float gravityScale = 5;

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
            myRigidbody.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * myRigidbody.gravityScale) * -2) * myRigidbody.mass;

            myRigidbody.velocity = Vector2.up * jumpForce;
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if (moveSpeed < 8)
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
            animator.SetBool("isJumping", false);
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
            gravityScale = gravityScale - 0.5f;
        }

        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            moveSpeed ++;
            gravityScale += 0.5f;
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
