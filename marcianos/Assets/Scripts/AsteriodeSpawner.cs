using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodeSpawner : MonoBehaviour
{
    public GameObject Spawner;
    public float respawnTime = 1.0f;
    private Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    private void SpawnEnemies()
    {
        Instantiate(Spawner,transform.position,Quaternion.identity);
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemies();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
