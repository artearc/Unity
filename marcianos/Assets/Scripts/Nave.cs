using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    [SerializeField] private float velocidad = 6;
    [SerializeField] Transform prefabDisparo;
    [SerializeField] Transform prefabExplosion;
    private float velocidadDisparo = 1;
    private gameManager manager;

    void Start()
    {
        manager = gameManager.Instance;
        Enemigo.enemigosRestantes = 4;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemigoDisparo" || collision.tag == "DisparoJefe" || collision.tag == "asteroide")
        {
            if (manager != null)
            {
                GetComponent<vidasNave>().PerderVida();
            }

            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal * velocidad * Time.deltaTime, vertical * velocidad * Time.deltaTime, 0);

        float limiteX = Camera.main.orthographicSize * Camera.main.aspect;
        float limiteY = Camera.main.orthographicSize;

        float nuevaPosX = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        float nuevaPosY = Mathf.Clamp(transform.position.y, -limiteY, limiteY);
        transform.position = new Vector3(nuevaPosX, nuevaPosY, transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            Transform disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
        }
    }
}

