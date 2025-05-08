using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirspyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpHeight;
    public float moveSpeed;
    private bool isJumping = false;


    private void Awake()
    {

        // Calculate movement direction
        

    }

    // Start is called before the first frame update
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
    
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            isJumping = false;
        }
    }
}
