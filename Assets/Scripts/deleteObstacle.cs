using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObstacle : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //L�scht "alte" Hindernisse und Brezeln

        if (collision.tag == "EndOfFrame")
        {
            Destroy(gameObject);
        }
    }
}
