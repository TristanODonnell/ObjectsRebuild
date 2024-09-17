using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pickupPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private float spawnTime;
   

    public void StartSpawner()
    {
        InvokeRepeating("SpawnSystem", spawnTime, spawnTime);
        
    }
    public void SpawnSystem()
    {
       GameObject selectedPrefab =  pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];
       Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

       GameObject spawnedObject = Instantiate(selectedPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

        spawnedObject.GetComponent<Pickup>().StartDespawn();
    }

}
