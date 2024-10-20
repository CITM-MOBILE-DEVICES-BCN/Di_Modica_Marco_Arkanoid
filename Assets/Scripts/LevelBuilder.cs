using UnityEngine;
using UnityEngine.UI;

public class LevelBuilder : MonoBehaviour
{
    public GameObject blockPrefab;
    public RectTransform parentTransform;
    public int portraitColumns = 4;
    public int portraitRows = 6;
    public int landscapeColumns = 6;
    public int landscapeRows = 4;
    public int blockWidth = 200;
    public int blockHeight = 40;

    private int currentColumns;
    private int currentRows;

    void Start()
    {
        AdjustForSafeArea();
        UpdateOrientation();
        BuildLevel();
    }

    void Update()
    {
        if (Screen.width < Screen.height)
        {
            if (currentColumns != portraitColumns || currentRows != portraitRows)
            {
                UpdateOrientation();
                BuildLevel();
            }
        }
        else if (Screen.width >= Screen.height)
        {
            if (currentColumns != landscapeColumns || currentRows != landscapeRows)
            {
                UpdateOrientation();
                BuildLevel();
            }
        }
    }

    void UpdateOrientation()
    {
        if (Screen.width >= Screen.height)
        {
            currentColumns = landscapeColumns;
            currentRows = landscapeRows;
        }
        else if (Screen.width < Screen.height)
        {
            currentColumns = portraitColumns;
            currentRows = portraitRows;
        }
    }

    void BuildLevel()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }

        Rect parentRect = parentTransform.rect;
        float blockWidth = parentRect.width / currentColumns;
        float blockHeight = parentRect.height / currentRows;

        for (int i = 0; i < currentColumns; i++)
        {
            for (int j = 0; j < currentRows; j++)
            {
                GameObject block = Instantiate(blockPrefab, parentTransform);
                RectTransform blockRect = block.GetComponent<RectTransform>();
            }
        }

        //float blockWidth = parentRect.width / currentColumns;
        //float blockHeight = parentRect.height / currentRows;

        //for (int i = 0; i < currentColumns; i++)
        //{
        //    for (int j = 0; j < currentRows; j++)
        //    {
        //        GameObject block = Instantiate(blockPrefab, parentTransform);
        //        RectTransform blockRect = block.GetComponent<RectTransform>();

        //        blockRect.sizeDelta = new Vector2(blockWidth, blockHeight);
        //        GetComponent<GridLayoutGroup>().cellSize = new Vector2(blockWidth, blockHeight);

        //        blockRect.anchoredPosition = new Vector2(i * blockWidth, -j * blockHeight);
        //    }
        //}
    }

    // Safe area support (test)
    void AdjustForSafeArea()
    {
        Rect safeArea = Screen.safeArea;
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
