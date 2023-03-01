using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [SerializeField] 
    GameObject enemyPrefab;
    [SerializeField]
    Transform spawnPoint;
    
    [SerializeField]
    float spawnTime = 1.0f;
    float lastSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + lastSpawn)
        {
            lastSpawn = Time.time + spawnTime;

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
