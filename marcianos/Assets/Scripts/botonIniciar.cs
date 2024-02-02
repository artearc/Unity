using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonIniciar : MonoBehaviour
{
    private gameManager manager;
    void Start()
    {
        manager = FindObjectOfType<gameManager>();

    }

    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    void Update()
    {
        
    }
}
