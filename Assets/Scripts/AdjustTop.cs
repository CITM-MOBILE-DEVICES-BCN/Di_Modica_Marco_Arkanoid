using UnityEngine;
using UnityEngine.UI;

public class AdjustTop : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;

    private float lastScreenHeight;
    private float lastScreenWidth;

    void Start()
    {
        lastScreenHeight = Screen.height;
        lastScreenWidth = Screen.width;
        AdjustTopPadding();
    }

    void Update()
    {
        if (Screen.height != lastScreenHeight || Screen.width != lastScreenWidth)
        {
            lastScreenHeight = Screen.height;
            lastScreenWidth = Screen.width;
            AdjustTopPadding();
        }
    }

    void AdjustTopPadding()
    {
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        int topPadding;

        if (screenHeight > screenWidth)
        {
            topPadding = Mathf.Clamp(Mathf.RoundToInt(350 * (screenHeight / 1080f)), 0, 350);
        }
        else
        {
            topPadding = Mathf.Clamp(Mathf.RoundToInt(130 * (screenWidth / 1920f)), 120, 150);
        }

        RectOffset padding = gridLayoutGroup.padding;
        padding.top = topPadding;
        gridLayoutGroup.padding = padding;
    }
}
