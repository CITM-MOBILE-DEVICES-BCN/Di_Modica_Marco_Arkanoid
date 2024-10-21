using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI levelText;

    void Update()
    {
        livesText.text = "Lives: " + GameManager.instance.GetLives();
        scoreText.text = "Score: " + GameManager.instance.GetScore();
        highScoreText.text = "High Score: " + GameManager.instance.GetHighScore();
        levelText.text = "Level: " + GameManager.instance.GetLevel();
    }
}
