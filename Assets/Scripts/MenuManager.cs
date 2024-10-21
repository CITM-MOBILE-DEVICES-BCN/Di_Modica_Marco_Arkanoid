using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject newGameButton;
    public GameObject settingsButton;

    private void Update()
    {
        if (GameManager.instance.playerData.score != 0)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void NewGame()
    {
        SceneManager.instance.LoadGame();
        GameManager.instance.ResetGame();
        GameManager.instance.playerData.Reset();
    }

    public void LoadGame()
    {
        SceneManager.instance.LoadGame();
        GameManager.instance.playerData.Load();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
