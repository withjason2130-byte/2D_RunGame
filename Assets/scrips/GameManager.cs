using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public Text Score_Txt;
    public GameObject GameOver_UI;
    public GameObject ReGame_txt;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(PlayerPrefs.GetInt("HighScore")< score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        /*
        if (!isGameOver)
        {
            score++;
            Score_Txt.text = "Score" + score;
        }
        */
    }

    public void Score_Cal(int new_Score)
    {
        if (!isGameOver)
        {
            score += new_Score;
            Score_Txt.text = "Score" + score;
        }
    }

    public void Dead_Trigger()
    {
        isGameOver = true;
        GameOver_UI.SetActive(true);
        Score_Txt.gameObject.SetActive(false);
        Invoke("ShowReGameTxt", 2f);
    }

    private void ShowReGameTxt()
    {
        GameOver_UI.SetActive(false);
        if (ReGame_txt != null)
        {
            ReGame_txt.SetActive(true);
        }
    }
}
