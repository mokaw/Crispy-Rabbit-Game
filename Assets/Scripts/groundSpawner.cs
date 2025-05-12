using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Vector3 nextSpawnPos;
    public GameObject[] obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        if (groundPrefab == null)
        {
            Debug.LogError("Ground Prefab ist nicht zugewiesen!");
        }
        else
        {
            Debug.Log("Ground Prefab OK: " + groundPrefab.name);
        }
        SpawnGround();
    }

    public void SpawnGround()
    {
       GameObject temp = Instantiate(groundPrefab, nextSpawnPos, Quaternion.identity);
       nextSpawnPos = temp.transform.GetChild(1).transform.position;

        int obstacleNum = Random.Range(0, 3);
        for(int i=0; i < obstacleNum; i++)
        {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            BoxCollider2D colGround = temp.GetComponent<BoxCollider2D>();
            float groundWidth = colGround.size.x * transform.localScale.x;
            float leftPos = temp.transform.position.x - (groundWidth / 2 - 1);
            float rightPos = temp.transform.position.x + (groundWidth / 2 - 1);
            float x = Random.Range(leftPos, rightPos);
            Vector3 pos = new Vector3(x, -6, transform.position.y);

            //TODO: Obstale müssen einen bestimmten Abstand zueinander haben

            GameObject obstacle = Instantiate(obstacleToSpawn, pos, Quaternion.identity);

            //deleteObstacle(obstacle);
            

        }

     
    }

    private void deleteObstacle(GameObject obs)
    {
        Destroy(obs, 30f);
        //TODO: Obstacle nach einer bestimmten Zeit löschne --> wenn mit dem Boxcollider von ground collidiert/verlässt
       
    }
}
