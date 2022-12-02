using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerTrain : MonoBehaviour
{
    public UnityEngine.UI.Text[] scoreText;
    private int score = 0;

    void Update() 
    {
        foreach (UnityEngine.UI.Text text in scoreText)
        {
            text.text = "Puntaje: " + score + " puntos";

        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
