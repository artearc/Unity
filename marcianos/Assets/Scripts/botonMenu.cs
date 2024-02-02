using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonMenu : MonoBehaviour
{
    private gameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<gameManager>();
    }

    public void LanzarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
