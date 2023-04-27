using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    /*public GameObject itemPrefab;
    public Tilemap tilemap;
    public Tilemap wallTile;

    private void Start()
    {
        SpawnItem();
    }


    public void SpawnItem()
    {
        // Get the bounds of the tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Choose a random position within the bounds of the tilemap
        Vector3Int randomPosition = new Vector3Int(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0);

        // Check if the chosen position is a wall tile
        if (tilemap.GetTile(randomPosition) == wallTile)
        {
            // The position is a wall tile, so try again
            SpawnItem();
            return;
        }

        // Instantiate the item at the chosen position
        Instantiate(itemPrefab, tilemap.CellToWorld(randomPosition), Quaternion.identity);
    }*/
    
    public GameObject itemPrefab;
    public Transform[] spawnPointTransforms;
    private Vector3[] spawnPoints;

    private void Start()
    {
        SpawnItem();
        // Convert the Transform positions to Vector3 positions
        spawnPoints = new Vector3[spawnPointTransforms.Length];
        for (int i = 0; i < spawnPointTransforms.Length; i++)
        {
            spawnPoints[i] = spawnPointTransforms[i].position;
        }
    }

    public void SpawnItem()
    {
        // Choose a random spawn point from the array
        Vector3 randomPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the item at the chosen position
        Instantiate(itemPrefab, randomPosition, Quaternion.identity);
    }
}
