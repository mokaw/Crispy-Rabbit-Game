using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CirspyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpHeight;
    public int moveSpeed;
    private bool isJumping = false;
    public Animator animator;
    public Animator speedAnimator;
    public GameOver GameOver;
    public Winning Winning;

    [SerializeField] float gravityScale = 5;
    public GameObject speedUI;
    public int distanceCrispy;
    private float startPos;

    private bool hasCollided = false;

    void Start()
    {
        
        CapsuleCollider2D isGround = gameObject.GetComponent<CapsuleCollider2D>();
        speedAnimator = speedUI.GetComponent<Animator>();
        startPos = transform.position.x;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time Scale: " + Time.timeScale);
        gameObject.transform.position += Vector3.right * Time.deltaTime * moveSpeed;  // deltaTime = Einheiten pro Sekunde 
                                                                                      // ohne deltaTime = Einheiten pro Frame                                
        distanceCrispy = (int) (transform.position.x - startPos);    

        if (Input.GetMouseButton(0) && !isJumping)
        {

            myRigidbody.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * myRigidbody.gravityScale) * -2) * myRigidbody.mass;

            myRigidbody.linearVelocity = Vector2.up * jumpForce;
            isJumping = true;
            animator.SetBool("isJumping", true);
            
        }

        if (moveSpeed <= 8)
        {
            Debug.Log("Quit triggered");
            Time.timeScale = 0f;
            GameOver.Setup();
            moveSpeed = 0;
        }
        
    }

    IEnumerator ResetCollisionFlag()
    {
        yield return new WaitForSeconds(0.01f);
        hasCollided = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("triggersObstacle", false);
        }

        if (other.CompareTag("spawnGround"))
        {
            FindObjectOfType<groundSpawner>().SpawnGround();
        }

        if (!hasCollided)
        {
            if (other.CompareTag("Obstacle"))
            {
                Debug.Log("Collision with Obstacle");
                hasCollided = true;
                Destroy(other.gameObject);
                moveSpeed--;
                gravityScale = gravityScale - 0.5f;
                animator.SetBool("triggersObstacle", true);
                speedAnimator.SetInteger("playerSpeed", moveSpeed);

                StartCoroutine(ResetCollisionFlag());
                

            }

            if (other.CompareTag("PowerUp"))
            {
                hasCollided = true;
                Destroy(other.gameObject);
                moveSpeed++;
                gravityScale += 0.5f;
                speedAnimator.SetInteger("playerSpeed", moveSpeed);

                StartCoroutine(ResetCollisionFlag());
            }

            if (other.CompareTag("Rabbit"))
            {
                hasCollided = true;
                Debug.Log("Quit triggered");
                Time.timeScale = 0f;
                Winning.Setup(distanceCrispy);

            }
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
