using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{

    private float startPos;
    private float length;
    private GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;                                        //Startpos. des Hintergrunds
        length = this.GetComponent<SpriteRenderer>().bounds.size.x;             // Berechnet die Breite des Hintergrunds
        cam = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        // Berechnet wie weit der Hintergrund bewegen soll (parallaxEffect kann im Inspector angepasst werden)
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // Wenn Hintergrundbild außerhalb vom Frame ist, wird er verschoben
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        if( temp > startPos + length)
        {
            startPos += length;
        }
    }
}
