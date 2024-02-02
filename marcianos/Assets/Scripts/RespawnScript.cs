using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public float timeToRespawn;
    public float cdToRespawn;
    public GameObject enemyToRespawn;

    private void Start()
    {
        enemyToRespawn = transform.gameObject;
    }

    public IEnumerator RespawnEnemy()
    {
        enemyToRespawn.SetActive(false);
        yield return new WaitForSeconds(timeToRespawn);
        enemyToRespawn.SetActive(true);

    }

    void Update()
    {
        
    }
}
