using UnityEngine;
using UnityEngine.UI;

public class AdjustTop : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;

    private float lastScreenHeight;
    private float lastScreenWidth;

    void Start()
    {
        lastScreenHeight = Screen.height; // Inicializa la altura de la pantalla
        lastScreenWidth = Screen.width; // Inicializa el ancho de la pantalla
        AdjustTopPadding(); // Ajusta al inicio
    }

    void Update()
    {
        // Comprueba si la altura o el ancho de la pantalla ha cambiado
        if (Screen.height != lastScreenHeight || Screen.width != lastScreenWidth)
        {
            lastScreenHeight = Screen.height; // Actualiza la �ltima altura
            lastScreenWidth = Screen.width; // Actualiza el �ltimo ancho
            AdjustTopPadding(); // Ajusta solo el padding superior
        }
    }

    void AdjustTopPadding()
    {
        // Obt�n la altura y el ancho de la resoluci�n de la pantalla
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        // Calcula el padding superior basado en la altura y el ancho
        int topPadding;

        // Condici�n para pantallas altas
        if (screenHeight > screenWidth) // Si la pantalla es m�s alta que ancha
        {
            topPadding = Mathf.Clamp(Mathf.RoundToInt(350 * (screenHeight / 1080f)), 0, 350); // Ajuste m�ximo de 400
        }
        // Condici�n para pantallas ancha
        else
        {
            topPadding = Mathf.Clamp(Mathf.RoundToInt(130 * (screenWidth / 1920f)), 120, 150); // Ajuste m�ximo de 50
        }

        // Ajusta el padding superior
        RectOffset padding = gridLayoutGroup.padding;
        padding.top = topPadding; // Establece el padding superior
        gridLayoutGroup.padding = padding; // Aplica el nuevo padding
    }
}
