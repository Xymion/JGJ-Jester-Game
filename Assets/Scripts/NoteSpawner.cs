using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject ArrowSpawn;
    public bool stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        float spawnDelay = Random.Range(1f, 5f);
        float spawnTime = Random.Range(1f, 3f);
        InvokeRepeating("SpawnAndMoveObject", spawnTime, spawnDelay);
    }

    public void SpawnAndMoveObject()
    {
        Instantiate(ArrowSpawn, transform.position, transform.rotation);
        
    }

    
}
