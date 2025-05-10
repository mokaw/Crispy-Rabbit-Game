using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Vector3 nextSpawnPos;

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
    }
}
