using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoEnemigo : MonoBehaviour
{
    private float velocidadDisparo = 10;
    [SerializeField] Transform prefabExplosion;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -velocidadDisparo, 0);
    }
    private void OnBecameInvisible()
    {
        Debug.Log("Posicion: " + transform.position);
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
