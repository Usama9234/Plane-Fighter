using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverPanel;
    private void Start()
    {
        gameOverPanel.SetActive(false);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void gameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
}
