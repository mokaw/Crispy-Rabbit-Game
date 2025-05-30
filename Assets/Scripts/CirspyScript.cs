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
        speedAnimator = speedUI.GetComponent<Animator>();
        startPos = transform.position.x;                                               // Startpos. laden für Distanz-Anzeige
        Time.timeScale = 1f;                                                           // timescale = 1 --> Neustart nachdem das Spiel beendet wurde
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * moveSpeed;  // deltaTime = Einheiten pro Sekunde 
                                                                                      // ohne deltaTime = Einheiten pro Frame                                
        distanceCrispy = (int) (transform.position.x - startPos);    

        if (Input.GetMouseButton(0) && !isJumping)                                     // soll verhindern, dass Spieler in der Luft nochmal springen kann
        {

            myRigidbody.gravityScale = gravityScale;

            //Berechnet Sprungkraft, basienrd auf Sprunghöhe, Gravitation und Masse
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * myRigidbody.gravityScale) * -2) * myRigidbody.mass;   

            //Bewegt Spiele nach oben * jumpForce
            myRigidbody.linearVelocity = Vector2.up * jumpForce;


            isJumping = true;
            animator.SetBool("isJumping", true);
            
        }

        if (moveSpeed <= 8)
        {
            Time.timeScale = 0f;
            GameOver.Setup();
        }
        
    }

    IEnumerator ResetCollisionFlag()                            // soll verhindern, dass Spieler mehrmals mit einem Objekt kollidiert 
    {
        yield return new WaitForSeconds(0.01f);                 // kurz warten (nicht blockierend)
        hasCollided = false;                                    // danach Kollision wieder aktiviert
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
            FindObjectOfType<groundSpawner>().SpawnGround();             // ruft die Spawn-Methode für neuen Boden auf
        }

        if (!hasCollided)
        {
            if (other.CompareTag("Obstacle"))
            {
                hasCollided = true;
                Destroy(other.gameObject);
                moveSpeed--;
                gravityScale = gravityScale - 0.5f;
                animator.SetBool("triggersObstacle", true);
                speedAnimator.SetInteger("playerSpeed", moveSpeed);

                StartCoroutine(ResetCollisionFlag());                      // Coroutine stoppt Ausführung und fährtfort wo es aufgehört hat 
                

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
                Time.timeScale = 0f;                            
                Winning.Setup(distanceCrispy);                              // Spiel wird beendet; timeScale = 0 --> stoppt das Spiel

            }
        }





    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Hintergrund, welcher nicht mehr im Frame ist, wird gelöscht

        if (other.CompareTag("spawnGround"))
        {
            Destroy(other.gameObject, 2);
        }
    }
}
