using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    AudioManager audioManager;
    public static int originalValue = 1;
    public static int tempCoinMultiplierNum = 1;
    public static int permanentCoinMultiplierNum = 1;
    
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

            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                if(PlayerStatus.getItem() == PlayerStatus.Item.COIN_MULT)
                {
                     if (ScoreManager.instance != null)
                    {   
                        int multiplierNum = originalValue * PlayerStatus.tempCoinMult * PlayerStatus.PERMANENT_COIN_MULTIPLIER;
                        for (int i = 0; i < multiplierNum; i++)
                        {
                            ScoreManager.instance.Addpoint();
                        }
                    }
                }
                else
                {   
                    if (ScoreManager.instance != null)
                    {
                        ScoreManager.instance.Addpoint();
                    }
                }
                
            }
        }
    }
}

