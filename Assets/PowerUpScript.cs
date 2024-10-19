using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            StartCoroutine(SlowTime());

            GetComponent<UnityEngine.UI.Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            // Destroy(gameObject);
        }
    }

    IEnumerator SlowTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
    }
}
