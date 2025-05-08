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
        SpawnGround();
    }

    public void SpawnGround()
    {
        Instantiate(groundPrefab, nextSpawnPos, Quaternion.identity);
    }
}
