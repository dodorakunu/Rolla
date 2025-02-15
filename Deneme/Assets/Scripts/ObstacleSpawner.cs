using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject pointPrefab;
    public Transform player;
    private float spawnZ = 0f;
    private float tileLength = 20f;
    private int numberOfTiles = 5;
    private float safeZone = 30f;
    private List<GameObject> activeObjects = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnObject();
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > spawnZ - (numberOfTiles * tileLength))
        {
            SpawnObject();
            DeleteObject();
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-4, 4), 0.5f, spawnZ);

        // Rastgele engel veya puan spawn et
        if (Random.value < 0.7f) // %30 engel, %70 puan
        {
            GameObject obj = Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
            activeObjects.Add(obj);
        }
        else
        {
            GameObject obj = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            activeObjects.Add(obj);
        }

        spawnZ += tileLength;
    }

    void DeleteObject()
    {
        Destroy(activeObjects[0]);
        activeObjects.RemoveAt(0);
    }
}
