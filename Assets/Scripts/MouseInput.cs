using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : IInputController
{
    public Vector3 GetPaddlePosition(Vector3 currentPosition)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        //calculate de width of the paddle
        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        float halfPaddleWidth = paddle.GetComponent<RectTransform>().localScale.x;

        mousePosition.x = Mathf.Clamp(mousePosition.x,
                                      -Camera.main.orthographicSize * Camera.main.aspect + halfPaddleWidth,
                                      Camera.main.orthographicSize * Camera.main.aspect - halfPaddleWidth);

        return new Vector3(mousePosition.x, currentPosition.y, 0);
    }
}
