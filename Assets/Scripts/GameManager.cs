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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

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

    public void ResetGame()
    {
        SetScore(0);
        SetLives(3);
    }
}