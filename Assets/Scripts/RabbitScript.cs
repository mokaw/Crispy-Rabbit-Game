using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{
    public float moveSpeed;

    private float startPos;
    public float distanceRabbit;

    private void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * moveSpeed;

        distanceRabbit = transform.position.x - startPos;
    }
}
