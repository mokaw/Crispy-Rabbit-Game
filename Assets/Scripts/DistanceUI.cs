using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    public Text distanceTextCrispy;
    public Text distanceTextRabbit;
    CirspyScript player;
    RabbitScript rabbit;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CirspyScript>();
        rabbit = GameObject.FindGameObjectWithTag("Rabbit").GetComponent<RabbitScript>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTextCrispy.text = player.distanceCrispy.ToString("000000");
        distanceTextRabbit.text = rabbit.distanceRabbit.ToString("000000");
    }
}
