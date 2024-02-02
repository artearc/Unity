using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    void Start()
    {
        
    }

    public void UpdateScore(int puntos)
    {
        score += puntos;
        scoreText.text = "Score: " + score;
    }
}
