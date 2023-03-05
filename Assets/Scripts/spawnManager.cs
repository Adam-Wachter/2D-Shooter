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
    float minTime = 10.0f;
    [SerializeField]
    float maxTime = 20.0f;
    float spawnTime;
    //float lastSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateObject()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.SetActive(true);
        }
    }
}
