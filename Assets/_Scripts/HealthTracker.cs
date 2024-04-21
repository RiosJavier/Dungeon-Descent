using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    //public static ScoreManager instance;
    public static HealthTracker instance;

    public int health;
    public int numOfHearts;

    public static int shield;
    public int numOfShields;

    public GameObject[] hearts;
    public GameObject[] shields; 
    
    public Sprite fullHeart; //red heart
    public Sprite emptyHeart; //gray heart
    public Sprite missingHeart; //invisible

    public Sprite fullShield; //blue shield
    public Sprite emptyShield; //no shield

    AudioManager audioManager;


    private void Start()
    {
        health = 3;
        numOfHearts = 3;

        shield = 1;
        numOfShields = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts + PlayerStatus.PERMANENT_HEALTH_BOOST)
        {
            health = numOfHearts;
        }

        if (shield > numOfShields)
        {
            shield = numOfShields;
        }

        if(health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("death");
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
            }
            else
            {
                if(i < numOfHearts + PlayerStatus.PERMANENT_HEALTH_BOOST)
                {
                    hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
                }
                else
                {
                    hearts[i].GetComponent<SpriteRenderer>().sprite = missingHeart;
                }
                
            }
        }

        for(int i = 0; i < shields.Length; i++)
        {
            if(i < shield)
            {
                shields[i].GetComponent<SpriteRenderer>().sprite = fullShield;
            }
            else
            {
                shields[i].GetComponent<SpriteRenderer>().sprite = emptyShield;
            }
        }
    }

    public void decrementHearts()
    {
        if(!PlayerStatus.isInvincible)
        {
            if(shield > 0)
            {
                shield--;
            }
            else
            {
                health--;
            }
        }
        
        audioManager.PlaySFX(audioManager.Damage);
    }

    public void addHealth()
    {
        health++;
    }

    public void addShield()
    {
        shield++;
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
}
