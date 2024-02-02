using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private float velocidadX;
    private float velocidadY;
    private float tiempoCambioDireccion = 0.3f;
    private float tiempoUltimoCambio;
    public int vida = 10;
    [SerializeField] Transform prefabMisilJefe;
    [SerializeField] Transform prefabExplosionNave;
    private float velocidadDisparo = 7;
    private float tiempoEntreRafagas = 1.5f;

    private Camera mainCamera;

    void Start()
    {
        tiempoUltimoCambio = Time.time;
        mainCamera = Camera.main;
        StartCoroutine(Disparar());
    }
    public void PerderVida()
    {
        vida--;

        if (vida <= 0)
        {
            SceneManager.LoadScene("Win");
        }

    }
    IEnumerator Disparar()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreRafagas);

            StartCoroutine(RafagaDisparos());

            CambiarDireccionAleatoria();
        }
    }

    IEnumerator RafagaDisparos()
    {
        while (true)
        {
            float pausa = Random.Range(1.0f, 3f);
            yield return new WaitForSeconds(pausa);

            GetComponent<AudioSource>().Play();
            Transform disparo = Instantiate(prefabMisilJefe, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -velocidadDisparo, 0);
        }
       
    }

    void Update()
    {
        if (Time.time - tiempoUltimoCambio > tiempoCambioDireccion)
        {
            CambiarDireccionAleatoria();
        }

        transform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, 0);

        float limiteX = mainCamera.orthographicSize * mainCamera.aspect;
        float limiteY = mainCamera.orthographicSize;

        if ((transform.position.x < -limiteX) || (transform.position.x > limiteX) ||
            (transform.position.y < -limiteY) || (transform.position.y > limiteY))
        {
            CambiarDireccionAleatoria();
        }
    }


    void CambiarDireccionAleatoria()
    {
        velocidadX = Random.Range(-8f, 8f);
        velocidadY = Random.Range(-3f, 3f);

        if (velocidadX == 0 && velocidadY == 0)
        {
            velocidadX = 1f;
        }

        tiempoUltimoCambio = Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NaveDisparo")
        {
            Transform explosionNave = Instantiate(prefabExplosionNave, other.transform.position, Quaternion.identity);
            Destroy(explosionNave.gameObject, 1f);

            Destroy(other.gameObject);
        }
    }
}