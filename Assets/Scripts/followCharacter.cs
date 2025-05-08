using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CirspyScript player;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * player.moveSpeed * Time.deltaTime);
    }
}
