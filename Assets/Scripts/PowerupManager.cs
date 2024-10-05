using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private int powerUps = 10;
    private GameManager gMgr;

    private void Awake()
    {
        gMgr = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        while(powerUps > 0)
        {
            if (gMgr.score > 10)
            {
                Debug.Log("Powerup Given");
                powerUps--;
            }
            else if (powerUps == 0)
            {
                Debug.Log("None Left");
            }
        }
        
    }
}
