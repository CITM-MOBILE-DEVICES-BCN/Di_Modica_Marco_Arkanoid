using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 20f;
    public float speedIncrease = 0.05f;
    private Vector2 direction;
    private bool starting = true;

    public Transform paddleTransform;

    void Start()
    {
        StartCoroutine(StartBall());
    }

    void Update()
    {
        if (starting)
        {
            transform.position = new Vector3(paddleTransform.position.x, paddleTransform.position.y + 0.5f, 0);
        }
        
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        transform.Translate(speed * Time.deltaTime * direction);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x || transform.position.x > max.x)
        {
            direction.x = -direction.x;
            speed += speedIncrease;
        }

        if (transform.position.y > max.y)
        {
            direction.y = -direction.y;
            speed += speedIncrease;
        }

        if (transform.position.y < min.y)
        {
            //SceneManager.instance.MenuSceneAfterPlay();
            StartCoroutine(StartBall());
        }
    }

    private IEnumerator StartBall()
    {
        starting = true;
        yield return new WaitForSeconds(2);
        starting = false;
        direction = new Vector2(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed += speedIncrease;
        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector3 ballPosition = transform.position;
            Vector3 paddlePosition = collision.transform.position;

            float paddleWidth = collision.bounds.size.x;

            float offset = (ballPosition.x - paddlePosition.x) / (paddleWidth / 2);

            direction.y = -direction.y;

            direction.x = offset;
            direction.Normalize();
        }

        // Comprobar colisión con los bloques
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            direction.y = -direction.y;
        }
    }
}
