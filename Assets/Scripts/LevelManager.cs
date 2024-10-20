using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject levelOneBricks;
    public GameObject levelTwoBricks;
    public List<GameObject> levelBricks = new List<GameObject>();

    private void Start()
    {
        levelBricks.Clear();

        switch (GameManager.instance.playerData.level % 2)
        {
            case 1:
                levelOneBricks.SetActive(true);
                AddBricksToLevelList(levelOneBricks);
                break;
            case 2:
                levelTwoBricks.SetActive(true);
                AddBricksToLevelList(levelTwoBricks);
                break;
            default:
                levelOneBricks.SetActive(true);
                AddBricksToLevelList(levelOneBricks);
                break;
        }
    }

    private void AddBricksToLevelList(GameObject levelBrickContainer)
    {
        foreach (Transform child in levelBrickContainer.transform)
        {
            if (child.CompareTag("Brick"))
            {
                levelBricks.Add(child.gameObject);
            }
        }
    }

    private void Update()
    {
        if (levelBricks.Count == 0)
        {
            Debug.Log("Level Complete");
            GameManager.instance.playerData.level++;
            GameManager.instance.playerData.Save();
            SceneManager.instance.LoadVictory();
        }
    }
}
