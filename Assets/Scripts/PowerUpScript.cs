using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private BallController ballController;
    private int randomPowerUp;

    private void Start()
    {
        randomPowerUp = Random.Range(0, 3);
        Destroy(gameObject, 10f);
        ballController = FindObjectOfType<BallController>();

        switch (randomPowerUp)
        {
            case 0:
                GetComponent<UnityEngine.UI.Image>().color = Color.green;
                break;
            case 1:
                GetComponent<UnityEngine.UI.Image>().color = Color.red;
                break;
            case 2:
                GetComponent<UnityEngine.UI.Image>().color = Color.blue;
                break;
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            switch (randomPowerUp)
            {
                case 0:
                    ballController.speed += 2;
                    break;
                case 1:
                    ballController.speed -= 2;
                    break;
                case 2:
                    ballController.speed = 10;
                    break;
            }

            GetComponent<UnityEngine.UI.Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
