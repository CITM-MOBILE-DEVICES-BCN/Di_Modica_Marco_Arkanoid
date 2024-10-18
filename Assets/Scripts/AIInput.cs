using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : IInputController
{
    private Transform ball;
    private float paddleSpeed = 5f; 
    private float followMargin = 0.5f;

    public AIInput(Transform ballTransform, float speed, float margin)
    {
        ball = ballTransform;
        paddleSpeed = speed;
        followMargin = margin;
    }

    public Vector3 GetPaddlePosition(Vector3 currentPosition)
    {
        Vector3 ballPosition = ball.position;
        Vector3 targetPosition = new Vector3(ballPosition.x, currentPosition.y, 0);

        // Asegurarse de que la paleta no se salga de los límites de la pantalla
        float halfPaddleWidth = currentPosition.x / 2;

        targetPosition.x = Mathf.Clamp(targetPosition.x,
                                        -Camera.main.orthographicSize * Camera.main.aspect + halfPaddleWidth,
                                        Camera.main.orthographicSize * Camera.main.aspect - halfPaddleWidth);

        // Solo mueve la paleta si la bola está fuera del margen de seguimiento
        if (Mathf.Abs(ballPosition.x - currentPosition.x) > followMargin)
        {
            // Interpolación suave para el movimiento de la paleta
            float step = paddleSpeed * Time.deltaTime; // cantidad de movimiento en este frame
            return Vector3.MoveTowards(currentPosition, targetPosition, step);
        }

        return currentPosition; // Si está dentro del margen, mantén la posición actual
    }
}
