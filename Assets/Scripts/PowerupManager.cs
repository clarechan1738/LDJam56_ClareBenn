using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private int powerUps = 10;
    private GameManager gMgr;
    private MovementScript mScript;

    [SerializeField]
    private TextMeshProUGUI powerupTxt;

    private bool triggered = false;

    private int score;

    private void Awake()
    {
        gMgr = FindAnyObjectByType<GameManager>();
        mScript = FindAnyObjectByType<MovementScript>();
        powerupTxt.text = " ";
    }

    private void Update()
    {
        score = gMgr.score;

        if (score == 10)
        {
            powerUps--;
            mScript.acceleration = 8.5f;
            StopAllCoroutines();
            StartCoroutine(Countdown(0));
        }
        if (score == 20)
        {
            powerUps--;
            gMgr.maxHealth = 105;
            StopAllCoroutines();
            StartCoroutine(Countdown(1));
        }
        if (score == 30)
        {
            powerUps--;
            mScript.acceleration = 9f;
            StopAllCoroutines();
            StartCoroutine(Countdown(2));
        }
        if (score == 40)
        {
            powerUps--;
            gMgr.maxHealth = 110;
            StopAllCoroutines();
            StartCoroutine(Countdown(3));
        }
        if (score == 50)
        {
            powerUps--;
            mScript.acceleration = 9.5f;
            StopAllCoroutines();
            StartCoroutine(Countdown(4));
        }
        if (score == 60)
        {
            powerUps--;
            gMgr.playerHealth = gMgr.maxHealth;
            StopAllCoroutines();
            StartCoroutine(Countdown(5));
        }
        if (score == 70)
        {
            powerUps--;
            mScript.acceleration = 10.5f;
            StopAllCoroutines();
            StartCoroutine(Countdown(6));
        }
        if (score == 80)
        {                      
            powerUps--;
            gMgr.maxHealth = 125;
            StopAllCoroutines();
            StartCoroutine(Countdown(7));
        }
        if (score == 90)
        {
            powerUps--;
            mScript.acceleration = 11f;
            StopAllCoroutines();
            StartCoroutine(Countdown(8));
        }
        if (score == 100)
        {
            powerUps--;
            gMgr.maxHealth = 130;
            StopAllCoroutines();
            StartCoroutine(Countdown(9));
        }
        if(score > 100 && !triggered)
        {
            triggered = true;
            mScript.acceleration = 10.5f;
            gMgr.maxHealth = 145;
            StopAllCoroutines();
            StartCoroutine(Countdown(10));
        }


    }

    public IEnumerator Countdown(int powerupNum)
    {
        switch(powerupNum)
        {
            case 0:
                powerupTxt.text = "You Are Now A Bit Faster...";
                break;
            case 1:
                powerupTxt.text = "You Are Now A Bit Healthier...";
                break;
            case 2:
                powerupTxt.text = "Speed Increased...";
                break;
            case 3:
                powerupTxt.text = "Max Health Increased...";
                break;
            case 4:
                powerupTxt.text = "Speed Increased...";
                break;
            case 5:
                powerupTxt.text = "Health Refreshed...";
                break;
            case 6:
                powerupTxt.text = "Speed Increased Significantly...";
                break;
            case 7:
                powerupTxt.text = "Health Increased Significantly...";
                break;
            case 8:
                powerupTxt.text = "Speed Increased...";
                break;
            case 9:
                powerupTxt.text = "Health Increased...";
                break;
            case 10:
                powerupTxt.text = "You Are At Maximum Power!";
                break;
        }
        yield return new WaitForSeconds(3.0f);

        powerupTxt.text = " ";
    }
}
