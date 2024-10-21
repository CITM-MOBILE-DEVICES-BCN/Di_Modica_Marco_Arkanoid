using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private BallController ballController;
    public Color color1;
    public Color color2;
    public Color color3;
    public TextMeshProUGUI powerUpText;
    private int randomPowerUp;

    private void Start()
    {
        randomPowerUp = Random.Range(0, 3);
        Destroy(gameObject, 10f);
        ballController = FindObjectOfType<BallController>();

        switch (randomPowerUp)
        {
            case 0:
                GetComponent<UnityEngine.UI.Image>().color = color1;
                break;
            case 1:
                GetComponent<UnityEngine.UI.Image>().color = color2;
                break;
            case 2:
                GetComponent<UnityEngine.UI.Image>().color = color3;
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
                    ballController.speed += 4;
                    break;
                case 1:
                    ballController.speed -= 4;
                    break;
                case 2:
                    ballController.speed = 5;
                    break;
            }

            GetComponent<UnityEngine.UI.Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            powerUpText.enabled = true;
        }
    }
}
