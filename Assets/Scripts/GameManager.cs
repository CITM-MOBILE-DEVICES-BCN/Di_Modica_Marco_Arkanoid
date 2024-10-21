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
        Victory,
        Defeat
    }

    [Header("Game Variables")]
    public GameState currentGameState;
    public PlayerData playerData;

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

        playerData.LoadHighscore();

        Application.targetFrameRate = 60;
        Screen.SetResolution(1920 / 2, 1080 / 2, FullScreenMode.Windowed);
    }

    private void Update()
    {
        switch (SceneManager.instance.GetCurrentScene())
        {
            case "Menu":
                if (currentGameState != GameState.Menu)
                {
                    SetGameState(GameState.Menu);
                }
                break;
            case "Game":
                if (currentGameState != GameState.Game)
                {
                    SetGameState(GameState.Game);
                }
                break;
            case "Defeat":
                if (currentGameState != GameState.Defeat)
                {
                    SetGameState(GameState.Defeat);
                }
                break;
            case "Victory":
                if (currentGameState != GameState.Victory)
                {
                    SetGameState(GameState.Victory);
                }
                break;
            default:
                if (currentGameState != GameState.Menu)
                {
                    SetGameState(GameState.Menu);
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Screen.SetResolution(1920 / 2, 1080 / 2, FullScreenMode.Windowed);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Screen.SetResolution(1080 / 2, 1920 / 2, FullScreenMode.Windowed);
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

    public void SetLevel(int newLevel)
    {
        playerData.level = newLevel;
    }

    public int GetScore()
    {
        return playerData.score;
    }

    public int GetHighScore()
    {
        return playerData.highScore;
    }

    public int GetLives()
    {
        return playerData.lives;
    }

    public int GetLevel()
    {
        return playerData.level;
    }

    public void ResetGame()
    {
        SetScore(0);
        SetLives(3);
        SetLevel(1);
    }
}