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

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        health = 2;
        numOfHearts = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void decrementHearts()
    {
        health--;
    }

    public void addHealth()
    {
        health++;
    }

    void Awake()
    {
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
