using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class vidasNave : MonoBehaviour
{
    public int vidas = 3;
    public List<Transform> vidasUI;
    public Transform prefabExplosion;
    void Start()
    {
        vidasUI.Clear();
        GameObject lifes = GameObject.Find("Vidas");
        foreach (Transform t in lifes.transform)
        {
            vidasUI.Add(t);
        }
        gameManager manager = FindObjectOfType<gameManager>();
       
        vidas = manager.vidasNave;

      
        ActualizarVidasUI();

    }

    public void PerderVida()
    {
        vidas--;

        ActualizarVidasUI();

    }

    void ActualizarVidasUI()
    {
        for (int i = 0; i < vidasUI.Count; i++)
        {
            if (i < vidas)
            {
                vidasUI[i].gameObject.SetActive(true);
            }
            else
            {
                vidasUI[i].gameObject.SetActive(false);
            }
        }

        if (vidas <= 0)
        {
            CrearExplosion();
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    void CrearExplosion()
    {
        if (prefabExplosion != null)
        {
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
    }
}


