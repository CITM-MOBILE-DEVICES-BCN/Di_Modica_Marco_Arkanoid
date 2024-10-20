using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseMenu;
    public PaddleController paddleController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        paddleController.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        paddleController.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GoToMenu()
    {
        ResumeGame();
        SceneManager.instance.LoadMenu();
    }
}
