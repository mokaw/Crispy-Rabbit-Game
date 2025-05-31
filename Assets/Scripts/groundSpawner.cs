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
        // Spawnt einen neuen Boden an nextSpawnPos
       GameObject temp = Instantiate(groundPrefab, nextSpawnPos, Quaternion.identity);

        //nextSpawnPos wird aktualisiert, basierend auf dem letzten Boden-Tiles (GameObjekt) des aktuellen Bodens 
        nextSpawnPos = temp.transform.GetChild(1).transform.position;
       

        // Zufällige Anzahl an Hindernissen und Brezeln wird generiert
        float tempObstaclePos = 0;
        float tempPowerUp = 0;
        int obstNum = Random.Range(0, 3);
        int powerUpNum = Random.Range(0, 2);

        BoxCollider2D playerCol = player.GetComponent<BoxCollider2D>();

        //Zufälliges Obsticals wird gewählt
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Bodenbreite wird anhand des Colliders und der Skalierung herausgefunden 
        BoxCollider2D colGround = temp.GetComponent<BoxCollider2D>();
        float groundWidth = colGround.size.x * transform.localScale.x;

        // Bestimmt den Anfang und das Ende des Bodens
        float leftPos = temp.transform.position.x - (groundWidth / 2 - 1);
        float rightPos = temp.transform.position.x + (groundWidth / 2 - 1);

        // Bestimmt eine x-Variable zwischen diesen zwei Punkten
        float x = Random.Range(leftPos, rightPos);
        Vector3 posObs;

        // Berechnet Breite von Crispy + Puffer (wegen Springen)
        float playerWidth = playerCol.size.x * transform.localScale.x + 8;


        for (int i=0; i < obstNum; i++)
        {   


            if (obstacleToSpawn.name == "Stone")
            {
                posObs = new Vector3 (x, -4.5f , -3);
            } else if(obstacleToSpawn.name == "Triangle")                               // "Triangle" = Baumstumpf
            {
                posObs = new Vector3 (x, -5.6f, -3);
            } else
            {
                posObs = new Vector3(x, -6.2f, -3);
            }
 
          
            
            //Es wird überprüft, ob das neue Obstacle größer ist als diese Breite, sodass die Hindernisse nicht zu nah beieinander sind
            if(posObs.x > (tempObstaclePos + playerWidth))
            {
                    // Wenn ja, dann erstelle ein neues Objekt an der Position tempObstaclePos
                    GameObject obstacle = Instantiate(obstacleToSpawn, posObs, Quaternion.identity); 
                    tempObstaclePos = obstacle.transform.position.x; 
                 
            }


        }

         for(int j = 0; j < powerUpNum; j++){
            // Neue Zufallsposition für Brezel wird erstellt
            x = Random.Range(leftPos, rightPos);
            Vector3 posPow = new Vector3(x + 20, 4, transform.position.z);


        // spawne neue Brezel, wenn diese weit genug weg ist von der letzten  
        if (posPow.x > (tempPowerUp + playerWidth))
        {
            GameObject powerUp = Instantiate(powerUpPrefab, posPow, Quaternion.identity);
            tempPowerUp = powerUp.transform.position.x;
        }


        }

        



    }

}
