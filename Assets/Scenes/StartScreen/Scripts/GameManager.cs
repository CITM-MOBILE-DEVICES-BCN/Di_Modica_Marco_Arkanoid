using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Settings,
        GameOver
    }

    [Header("Game Variables")]
    GameState currentGameState;
    private PlayerData playerData;
    private SettingsData settingsData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerData = new PlayerData(3, 0, 0, 1);
        settingsData = new SettingsData(1.0f, 0);
        
        playerData.Load();
        settingsData.Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (SceneManager.GetCurrentScene())
        {
            case "Menu":
                if (currentGameState != GameState.Menu)
                {
                    SetGameState(GameState.Menu);
                }
                break;
            case "Game":
                if (currentGameState != GameState.Game || currentGameState != GameState.Pause)
                {
                    SetGameState(GameState.Game);
                }
                break;
            case "GameOver":
                if (currentGameState != GameState.GameOver)
                {
                    SetGameState(GameState.GameOver);
                }
                break;
            case "Settings":
                if (currentGameState != GameState.Settings)
                {
                    SetGameState(GameState.Settings);
                }
                break;
            default:
                if (currentGameState != GameState.Menu)
                {
                    SetGameState(GameState.Menu);
                }
                break;
        }
    }

    private void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
    }

    public void SetScore(int newScore)
    {
        playerData.score += newScore;

        if (playerData.score >= playerData.highScore)
        {
            SetHighScore(playerData.score);
        }
    }

    public void SetHighScore(int newHighScore)
    {
        playerData.highScore = newHighScore;
    }

    public void SetLives(int newLives)
    {
        playerData.lives = newLives;
    }

    public void ResetGame()
    {
        SetScore(0);
        SetLives(3);
    }
}