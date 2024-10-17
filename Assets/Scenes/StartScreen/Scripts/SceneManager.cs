using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager
{
    public static void MenuSceneAfterPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public static void MenuSceneAfterQuit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public static void LoadSettingsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }

    public static void NewGameScene()
    {
        
    }

    public static void ContinueScene()
    {

    }
}
