using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.Coin);
            Destroy(gameObject);

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.Addpoint();
            }
        }
    }
}

