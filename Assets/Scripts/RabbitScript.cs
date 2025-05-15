using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }
}
