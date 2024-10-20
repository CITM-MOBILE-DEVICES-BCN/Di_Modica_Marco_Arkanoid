using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int initialResistance;
    public int resistance;
    public Color[] colors;
    public UnityEngine.UI.Image image;
    public GameObject powerUp;
    public BoxCollider2D boxCollider;
    public bool destroyed = false;

    private bool powerUpInstanciado = false;

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
                        if (!powerUpInstanciado)
                        {
                            Instantiate(powerUp, GetComponentInParent<Transform>());
                            powerUpInstanciado = true;
                        }
                        break;
                }

                image.color = new Color(1, 1, 1, 0);
                boxCollider.enabled = false;
                destroyed = true;
            }
            else
            {
                image.color = colors[resistance - 1];
                boxCollider.enabled = true;
                destroyed = false;
            }
        }
    }

    public bool IsDestroyed()
    {
        return destroyed;
    }
}
