using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disparo : MonoBehaviour
{
    private float velocidadDisparo = 10;
    [SerializeField] Transform prefabExplosion;
    private PointManager pointManager;
    void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);

    }
    private void OnBecameInvisible()
    {
        Debug.Log("Posicion: " + transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
        {
            other.GetComponent<Enemigo>().PerderVida();
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }
        if(other.tag == "Jefe")
        {
            Transform explosion = Instantiate(prefabExplosion,
            other.transform.position, Quaternion.identity);
            pointManager.UpdateScore(50);
            Destroy(explosion.gameObject, 1f);
            other.GetComponent<Boss>().PerderVida();
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}


