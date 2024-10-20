using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.playerData.level++;
        GameManager.instance.playerData.Save();
    }

    public void NextLevel()
    {
        SceneManager.instance.LoadGame();
    }

    public void GoToMenu()
    {
        GameManager.instance.playerData.Save();
        SceneManager.instance.LoadMenu();
    }
}
