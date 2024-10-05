using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 100;
    private float timer = 180.0f;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private TextMeshProUGUI timerTxt;


    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindAnyObjectByType<GameManager>();
            }

            return _instance;
        }
    }


    void Update()
    {

        if(timer > 0)
        {
            timer -= Time.deltaTime * 1.0f;
        }
        else
        {
            GameWon();
        }

        var ts = TimeSpan.FromSeconds(timer);
        timerTxt.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        timerTxt.color = Color.white;
    }

    public void GameOver()
    {
        Destroy(playerObj);
        SceneManager.LoadScene("GameOver");
    }

    public void GameWon()
    {
        SceneManager.LoadScene("Credits");
    }
}
