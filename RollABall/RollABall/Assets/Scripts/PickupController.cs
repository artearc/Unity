using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Ajusta esta velocidad según sea necesario
    public float colorChangeInterval = 5.0f;

    private float timer;
    private Renderer pickupRenderer;


    void Start()
    {
        pickupRenderer = GetComponent<Renderer>();
        timer = colorChangeInterval;

        // Llamamos a la función para cambiar de color inicialmente
        ChangeColor();
    }

    void Update()
    {
        // Rotar el pickup de forma independiente
        transform.Rotate(new Vector3(15, 30, 45) * rotationSpeed * Time.deltaTime);

        // Contar el tiempo y cambiar de color cada 5 segundos
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            ChangeColor();
            timer = colorChangeInterval;
        }
    }

    void ChangeColor()
    {
        // Cambiar el color del pickup de forma aleatoria
        pickupRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
