using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private bool isPaused;

    public TextMeshProUGUI healthText;
    public GameObject pauseObj;
    public GameObject gameOverObj;

    // Awake is called before the Start
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x" + value.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }
}
