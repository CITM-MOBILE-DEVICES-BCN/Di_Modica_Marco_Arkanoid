using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    Menu,
    PLaying,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Variables")]
    GameState currentGameState;
    public int lives = 3;
    public int score = 0;
    public int highScore = 0;

    private void Awake()
    {
        
    }
}
