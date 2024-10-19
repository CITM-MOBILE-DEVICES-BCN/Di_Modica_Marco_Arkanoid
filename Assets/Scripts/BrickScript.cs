using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int initialResistance;
    public int resistance;
    public Color[] colors;
    public UnityEngine.UI.Image image;
    public Collider2D collider;
    public GameObject powerUp;

    private void Start()
    {
        resistance = Random.Range(1, 5);
        initialResistance = resistance;
        image.color = colors[resistance - 1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            resistance--;

            if (resistance <= 0)
            {
                
                switch (initialResistance)
                {
                    case 1:
                        GameManager.instance.SetScore(100);
                        break;
                    case 2:
                        GameManager.instance.SetScore(200);
                        break;
                    case 3:
                        GameManager.instance.SetScore(300);
                        break;
                    case 4:
                        GameManager.instance.SetScore(400);
                        Instantiate(powerUp, transform.position, Quaternion.identity);
                        break;
                }

                image.color = new(1,1,1,0);
                collider.enabled = false;
            }
            else
            {
                image.color = colors[resistance - 1];
            }
        }
    }
}
