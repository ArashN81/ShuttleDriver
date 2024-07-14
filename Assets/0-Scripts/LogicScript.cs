using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public float timer = 0f;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text HighestScore;

    private void Start()
    {
        Time.timeScale = 1;
        timer = 0;
        GameTimer();
        if (HighestScore != null)
        HighestScore.text = PlayerPrefs.GetInt("Highest").ToString();
    }

    //allows you to add function into Menu of the script
    [ContextMenu("add")]
    public void AddScore(int numberToAdd)
    {
        playerScore += numberToAdd;
        scoreText.text = playerScore.ToString();
        //Add score to file

    }

    public void HandlePause()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        GameTimer();
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu!= null)
        {
            HandlePause();
            //pauseMenu.activeSelf ? pauseMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    public void GameTimer()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer.ToString());
    }
}
