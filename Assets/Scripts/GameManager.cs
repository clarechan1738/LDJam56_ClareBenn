using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 100;
    public int maxHealth = 100;

    public HealthBar healthBar;

    private float timer = 180.0f;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private TextMeshProUGUI timerTxt;

    public int score = 0;

    private ScoreScript sScript;

    [SerializeField]
    private TextMeshProUGUI playerHealthTxt;
    [SerializeField]
    private TextMeshProUGUI maxHealthTxt;

    [SerializeField]
    private GameObject pauseMenu;



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


    private void Awake()
    {
        Time.timeScale = 1;
        sScript = FindAnyObjectByType<ScoreScript>();
        playerHealthTxt.text = " ";
        maxHealthTxt.text = " ";
    }

    private void Start()
    {
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Time.timeScale == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if(Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }

        //Update Text In Scene To Display The Current & Maximum Health
        playerHealthTxt.text = playerHealth.ToString();
        maxHealthTxt.text = maxHealth.ToString();

        //Counts Down Timer, When It Ends & Player Survives, Loads The Win Function
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1.0f;
        }
        else
        {
            GameWon();
        }

        //Displays The Timer In Minutes & Seconds Format
        var ts = TimeSpan.FromSeconds(timer);
        timerTxt.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        timerTxt.color = Color.white;
    }

    //Ends The Game
    public void GameOver()
    {
        Destroy(playerObj);
        SceneManager.LoadScene("GameOver");
    }

    public void GameWon()
    {
        sScript.SetScore(score);

        SceneManager.LoadScene("Credits");
    }
}
