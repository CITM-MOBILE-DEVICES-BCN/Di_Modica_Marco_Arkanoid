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

    public void MenuSceneAfterPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void MenuSceneAfterQuit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void SettingsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }

    public void NewGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ContinueScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public string GetCurrentScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
