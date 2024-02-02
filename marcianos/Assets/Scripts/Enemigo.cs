using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    public static int enemigosRestantes = 4;
    private float velocidadX;
    private float velocidadY;
    private float tiempoCambioDireccion = 0.6f;
    private float tiempoUltimoCambio;
    public int vida = 2;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] Transform prefabDisparoEnemigo;
    private float velocidadDisparo = 1;

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
            Transform explosion = Instantiate(prefabExplosion,
            transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            enemigosRestantes--;
            Destroy(gameObject);
        }

    }

    void OnDestroy()
    {
        
        Debug.Log("Enemigos restantes: " + enemigosRestantes);

        if (enemigosRestantes <= 0)
        {
            Debug.Log("Cargando el nivel final...");

            if (gameManager.Instance != null)
            {
                gameManager.Instance.vidasNave = FindObjectOfType<vidasNave>().vidas;
                gameManager.Instance.LoadLevel();
            }
            else
            {
                Debug.LogError("gameManager.Instance es nulo.");
            }
        }
    }

    IEnumerator Disparar()
    {
        while (true)
        {
            float pausa = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(pausa);

            Transform disparo = Instantiate(prefabDisparoEnemigo, transform.position, Quaternion.identity);
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
        velocidadX = Random.Range(-6f, 6f);
        velocidadY = Random.Range(-2f, 2f);

        if (velocidadX == 0 && velocidadY == 0)
        {
            velocidadX = 1f;
        }

        tiempoUltimoCambio = Time.time;
    }
}



