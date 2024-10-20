using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManager : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.playerData.Reset();
    }

    public void GoToMenu()
    {
        SceneManager.instance.LoadMenu();
    }
}
