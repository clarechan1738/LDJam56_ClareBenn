using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1;
    }

    //Literally Just Loads 3 Scenes.
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTutorial()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadRealCreds()
    {
        SceneManager.LoadScene("CreditsReal");
    }

}
