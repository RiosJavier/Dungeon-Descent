using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthPotion : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.HealthPotion);
            Destroy(gameObject);

            if (HealthTracker.instance != null)
            {
                HealthTracker.instance.addHealth();
            }
        }
    }
}
