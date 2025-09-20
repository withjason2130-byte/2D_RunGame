using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public Text High_Score;

    public void Start()
    {
        High_Score.text = "High Score : " + PlayerPrefs.GetInt("High_Score") + "점";
    }
    public void Play()
    {
        SceneManager.LoadScene("play");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
