using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //public static ScoreManager instance;
    public static EnemyHealth instance;

    public int health;

    AudioManager audioManager;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) 
        {
            Destroy(gameObject);
        }
    }

    public void decrementHearts()
    {
        if(!PlayerStatus.damageDebuff)
        {
            health--;
            audioManager.PlaySFX(audioManager.Enemy);
        }
    }

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (instance == null)
        {
            instance = this;
            // Optionally, to persist the ScoreManager across scenes, uncomment the following line:
            // DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy any duplicate instances that may be created
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerStatus.damageDebuff)
        {
            if(collision.tag == "Sword")
            {
                Debug.Log("Collision detected");
                ScoreManager.instance.Addpoint();
                decrementHearts();
            }
            if(collision.tag == "Arrow")
            {
                if (HealthTracker.instance != null)
                {   
                    ScoreManager.instance.Addpoint();
                    decrementHearts();
                }
            }
        }
    }
}