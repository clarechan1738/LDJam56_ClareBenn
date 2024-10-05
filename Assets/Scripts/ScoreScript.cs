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
        DontDestroyOnLoad(gameObject);
    }

    public void SetScore(int tScore)
    {
        score = tScore;
    }

    public int GetScore()
    {
        return score;
    }

}