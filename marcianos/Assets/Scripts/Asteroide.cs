using UnityEngine;

public class Asteroide : MonoBehaviour
{
    float velocidadAsteroideX;
    float velocidadAsteroideY;

    // Start is called before the first frame update
    void Start()
    {
        // Invocar la función para iniciar el movimiento después de un retraso aleatorio
        Invoke("IniciarMovimiento", Random.Range(2.0f, 5.0f));
        
    }

    void IniciarMovimiento()
    {
        velocidadAsteroideX = Random.Range(4.0f, 8.0f);
        velocidadAsteroideY = Random.Range(7.0f, 20.0f);

        // Asegurémonos de que los asteroides caigan hacia abajo
        velocidadAsteroideY = Mathf.Abs(velocidadAsteroideY);

        if (transform.position.x > 0)
            velocidadAsteroideX = velocidadAsteroideX * -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadAsteroideX * Time.deltaTime, -velocidadAsteroideY * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
