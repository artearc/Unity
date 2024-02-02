using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private int count;
    private Rigidbody rb;
    public TextMeshProUGUI countText;
    public Camera camera;
    public float fuerzaDeSalto = 5;
    private Renderer r;
    public GameObject youWinText;
    public AudioSource pickupAudioSource;
    public AudioSource changeScene;
    public AudioSource winGame;

    // Escala inicial del jugador
    private Vector3 initialScale;

    // Número de veces que el jugador ha chocado con la pared
    private int wallCollisions = 0;

    // Mínimo tamaño al que el jugador puede reducirse
    public float minScale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        youWinText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        r = GetComponent<Renderer>();
        count = 0;
        SetCountText();
        camera = Camera.main;

        // Guardar la escala inicial del jugador
        initialScale = transform.localScale;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            // Cambiar a la escena "Laberinto" cuando se recogen suficientes pickups
            changeScene.Play();
            SceneManager.LoadScene("Laberinto");
        }
    }

    private void Update()
    {
        // Saltar cuando se presiona el botón de salto y no está en el aire
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Mover al jugador en función de las entradas de movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = (transform.forward * moveVertical) + (transform.right * moveHorizontal);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Incrementar el contador de colisiones con la pared
            wallCollisions++;

            // Calcular el nuevo tamaño del jugador en función del número de colisiones
            float newScale = Mathf.Clamp(1.0f - (0.1f * wallCollisions), minScale, 1.0f);

            // Aplicar el nuevo tamaño al jugador
            transform.localScale = initialScale * newScale;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Desactivar el pickup y actualizar el contador
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            pickupAudioSource.Play();

            // Restablecer el contador de colisiones con la pared cuando se recoge un pickup
            wallCollisions = 0;

            // Hacer que el jugador crezca al recoger un pickup
            transform.localScale = initialScale * 1.2f;
        }
        if (other.gameObject.CompareTag("Endgame"))
        {
            // Mostrar el texto de victoria cuando se alcanza el área de fin del juego
            winGame.Play();
            youWinText.SetActive(true);
        }
    }
}
