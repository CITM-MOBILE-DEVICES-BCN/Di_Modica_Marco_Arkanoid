using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 20f;
    public float speedIncrease = 0.05f;
    public Vector2 direction;
    public bool starting = true;
    public Rigidbody2D rb;
    private bool isColliding = false;

    public Transform paddleTransform;

    void Start()
    {
        StartCoroutine(StartBall());
    }

    void Update()
    {
        if (starting)
        {
            transform.position = new Vector3(paddleTransform.position.x, paddleTransform.position.y + 0.4f, 0);
        }
        
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        transform.Translate(direction * speed * Time.deltaTime);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x)
        {
            transform.position = new Vector3(min.x + .01f, transform.position.y, 0);
            direction.x = -direction.x;
            speed += speedIncrease;
        }
        
        if (transform.position.x > max.x)
        {
            transform.position = new Vector3(max.x - .01f, transform.position.y, 0);
            direction.x = -direction.x;
            speed += speedIncrease;
        }
        
        if (transform.position.y < min.y)
        {
            GameManager.instance.SetLives(GameManager.instance.GetLives() - 1);

            if (GameManager.instance.GetLives() > 0)
            {
                speed = 0f;
                StartCoroutine(StartBall());
            }
            else
            {
                SceneManager.instance.LoadDefeat();
                GameManager.instance.playerData.Reset();
            }
        }
        
        if (transform.position.y > max.y)
        {
            transform.position = new Vector3(transform.position.x, max.y - .01f, 0);
            direction.y = -direction.y;
            speed += speedIncrease;
        }
    }

    private IEnumerator StartBall()
    {
        starting = true;
        yield return new WaitForSeconds(2);
        speed = 5f;
        starting = false;
        direction = new Vector2(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding) return;

        isColliding = true;

        speed += speedIncrease;

        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector3 ballPosition = transform.position;
            Vector3 paddlePosition = collision.transform.position;

            float paddleWidth = collision.bounds.size.x;

            float offset = (ballPosition.x - paddlePosition.x) / (paddleWidth / 2);

            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0);
            direction.y = -direction.y;

            direction.x = offset;
            direction.Normalize();
        }

        // Brick collision (NOT YET FINISHED)
        if (collision.gameObject.CompareTag("Brick"))
        {
            Vector2 ballPosition = transform.position;
            Bounds brickBounds = collision.bounds;

            float distLeft = Mathf.Abs(ballPosition.x - brickBounds.min.x);
            float distRight = Mathf.Abs(ballPosition.x - brickBounds.max.x);
            float distUp = Mathf.Abs(ballPosition.y - brickBounds.max.y);
            float distDown = Mathf.Abs(ballPosition.y - brickBounds.min.y);

            if (distLeft < distRight && distLeft < distUp && distLeft < distDown)
            {
                direction.x = -direction.x;
            }
            else if (distRight < distLeft && distRight < distUp && distRight < distDown)
            {
                direction.x = -direction.x;
            }
            else if (distUp < distLeft && distUp < distRight && distUp < distDown)
            {
                direction.y = -direction.y;
            }
            else if (distDown < distLeft && distDown < distRight && distDown < distUp)
            {
                direction.y = -direction.y;
            }
        }

        StartCoroutine(ResetCollision());
    }

    private IEnumerator ResetCollision()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}