using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lives;
    public int score;
    public int highScore;
    public int level;

    public PlayerData(int lives, int score, int highScore, int level)
    {
        this.lives = lives;
        this.score = score;
        this.highScore = highScore;
        this.level = level;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        lives = PlayerPrefs.GetInt("Lives", 3);
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        level = PlayerPrefs.GetInt("Level", 1);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.Save();
    }

    public void LoadHighscore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}