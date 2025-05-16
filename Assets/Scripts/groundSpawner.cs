using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Vector3 nextSpawnPos;
    public GameObject[] obstaclePrefabs;
    public GameObject player;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
             
        SpawnGround();
    }

    public void SpawnGround()
    {
       GameObject temp = Instantiate(groundPrefab, nextSpawnPos, Quaternion.identity);
       nextSpawnPos = temp.transform.GetChild(1).transform.position;
       
        float tempObstaclePos = 0;
        float tempPowerUp = 0;
        int obstacleNum = Random.Range(0, 4);
        int powerUpNum = Random.Range(0, 2);

        for (int i=0; i < obstacleNum; i++)
        {   
           
            BoxCollider2D playerCol = player.GetComponent<BoxCollider2D>();
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            BoxCollider2D colGround = temp.GetComponent<BoxCollider2D>();
            float groundWidth = colGround.size.x * transform.localScale.x;
            float leftPos = temp.transform.position.x - (groundWidth / 2 - 1);
            float rightPos = temp.transform.position.x + (groundWidth / 2 - 1);

            float x = Random.Range(leftPos, rightPos);
            Vector3 posObs;


            if (obstacleToSpawn.name == "Stone")
            {
                posObs = new Vector3 (x, -4.3f , transform.position.z);
            } else if(obstacleToSpawn.name == "Triangle")
            {
                posObs = new Vector3 (x, -5.6f, -3.1f);
            } else
            {
                posObs = new Vector3(x, -9.9f, -4.4f);
            }
           
            x = Random.Range(leftPos, rightPos);
            Vector3 posPow = new Vector3(x +20, 4, transform.position.z);
          

            float playerWidth = playerCol.size.x * transform.localScale.x + 6;
          

            if(posObs.x > (tempObstaclePos + playerWidth))
            {
                    GameObject obstacle = Instantiate(obstacleToSpawn, posObs, Quaternion.identity); 
                    tempObstaclePos = obstacle.transform.position.x; 
                 
            }

             for(int j=0; j < powerUpNum; j++)
                    {
                        if(posPow.x > (tempPowerUp + playerWidth) && posPow.x != (posObs.x + 3))
                                    {
                                        GameObject powerUp = Instantiate(powerUpPrefab, posPow, Quaternion.identity);
                                        tempPowerUp = powerUp.transform.position.x;
                                    }
            
                    }

            


        }

       


     
    }

}
