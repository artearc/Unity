
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public int vidasNave = 3;

    void Start()
    {

    }
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("NivelFinal");
    }


    void Update()
    {
    }
}
