using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private int powerUps = 10;
    private GameManager gMgr;

    private int score;

    private void Awake()
    {
        gMgr = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        score = gMgr.score;

        if (score == 10)
        {
            powerUps--;
        }
        if (score == 20)
        {
            powerUps--;
        }
        if (score == 30)
        {
            powerUps--;
        }
        if (score == 40)
        {
            powerUps--;
        }
        if (score == 50)
        {
            powerUps--;
        }
        if (score == 60)
        {
            powerUps--;
        }
        if (score == 70)
        {
            powerUps--;
        }
        if (score == 80)
        {                      
            powerUps--;
        }
        if (score == 90)
        {
            powerUps--;
        }
        if (score == 100)
        {
            powerUps--;
        }
        if(score > 100 && powerUps <= 0)
        {
        }


    }
}
