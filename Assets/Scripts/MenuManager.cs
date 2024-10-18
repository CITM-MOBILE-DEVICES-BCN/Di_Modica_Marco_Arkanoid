using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.instance.NewGameScene();
        GameManager.instance.playerData.Reset();
    }

    public void LoadGame()
    {
        SceneManager.instance.ContinueScene();
        GameManager.instance.playerData.Load();
    }

    public void Settings()
    {
        SceneManager.instance.SettingsScene();
    }
}
