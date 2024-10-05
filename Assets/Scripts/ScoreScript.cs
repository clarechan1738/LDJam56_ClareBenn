using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score;

    private void Awake()
    {
        //Saves The GameObject Across Scenes To Keep The Score Variable For The Credits
        DontDestroyOnLoad(gameObject);
    }

    //Score Getter & Setter Functions
    public void SetScore(int tScore)
    {
        score = tScore;
    }

    public int GetScore()
    {
        return score;
    }

}