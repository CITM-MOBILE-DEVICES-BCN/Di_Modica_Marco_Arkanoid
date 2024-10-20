using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

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
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void LoadVictory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }

    public void LoadDefeat()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Defeat");
    }    

    public string GetCurrentScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
