using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PermaHeartScript : MonoBehaviour
{
    public enum permaBuffType
    {
        HEART, COIN, DAMAGE
    }

    public int price;
    public GameObject text;
    public permaBuffType type;
    AudioManager audioManager;
    

    public void Start()
    {
        //need to set price.
        generatePrice();
        setText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && price <= PlayerStatus.coinCount)
        {
            audioManager.PlaySFX(audioManager.PermBuff);
            Destroy(gameObject);
            PlayerStatus.subtractCoins(price);
            switch (type)
            {
                case permaBuffType.COIN:
                    PlayerStatus.PERMANENT_COIN_MULTIPLIER++; break;
                case permaBuffType.DAMAGE: 
                    PlayerStatus.PERMANENT_DAMAGE_MULTIPLIER++; break;
                case permaBuffType.HEART: 
                    PlayerStatus.PERMANENT_HEALTH_BOOST++; break;
            }
        }
    }

    public void generatePrice()
    {
        price = Random.Range(80 + 20*LoaderBorder.shopkeeperCount, 201 + 20*LoaderBorder.shopkeeperCount);
    }

    public void setText()
    {
        text.GetComponent<TextMeshProUGUI>().text = price.ToString();
    }

    void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
