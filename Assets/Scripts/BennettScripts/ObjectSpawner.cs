using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Sphere prefab; will spawn several of these at random-ish intervals
    public GameObject sphereObjectPreFab;
    // Next time to drop new sphere
    private float nextDropTime = 0;
    // Size of object
    private float sphereSize;
    // Spawn position of sphere
    private Vector3 spawnPosition;
    // Transform of ObjectSpawner
    private Transform objectSpawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextDropTime) {
            // Drop a new sphere every 2 - 5 seconds
            nextDropTime = Time.time + Random.Range(2.0f, 5.0f);
            spawnPosition = new Vector3(Random.Range(-2.0f, 14.0f), objectSpawnerTransform.position.y, objectSpawnerTransform.position.z);
            GameObject sphere = Instantiate(sphereObjectPreFab, spawnPosition, Quaternion.identity);
        }
    }
}
