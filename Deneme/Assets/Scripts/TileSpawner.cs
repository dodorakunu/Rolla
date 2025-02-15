using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;  // Zemin Prefab'i
    public Transform player;       // Oyuncu (Top veya karakter)
    private float spawnZ = 0f;     // Son spawn edilen konum
    private float tileLength = 20f; // Her zemin uzunluðu
    private int numberOfTiles = 5; // Baþlangýçta kaç parça var
    private float safeZone = 30f;  // Silme mesafesi
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(i == 0 ? true : false);
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > spawnZ - (numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile(bool firstTile = false)
    {
        GameObject go = Instantiate(tilePrefab, Vector3.forward * spawnZ, Quaternion.identity);
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
