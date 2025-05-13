using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObstacle : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndOfFrame")
        {
            Destroy(gameObject);
        }
    }
}
