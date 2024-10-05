using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 100;
    private float timer = 180.0f;

    [SerializeField]
    private GameObject playerObj;


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
            GameOver();
        }

    }

    public void GameOver()
    {
        Destroy(playerObj);
    }
}
