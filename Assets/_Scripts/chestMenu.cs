using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using TMPro;

public class chestMenu : MonoBehaviour
{
    public List<Sprite> sprites;

    public GameObject chestUI;
    public GameObject lucky;
    public GameObject unlucky;

    public GameObject luckyPercent;
    public GameObject unluckyPercent;
    public GameObject currentCoins;

    public Image luckyItem;
    public Image unluckyItem;

    private int luckPercent;
    private int coinsSpent;

    // Start is called before the first frame update
    void Start()
    {
        chestUI.SetActive(false);
        lucky.SetActive(false);
        unlucky.SetActive(false);
        luckPercent = 0;
        coinsSpent = 0;
        currentCoins.GetComponent<TextMeshProUGUI>().text = "0";
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Chest Menu Loaded!");
            setLuckiness();
            updatePercent();
            ToggleChestMenu();
        }
    }

    public void setLuckiness()
    {
        if (LoaderBorder.roomCount < 10)
            luckPercent = Random.Range(50, 75);
        else if (LoaderBorder.roomCount < 20)
            luckPercent = Random.Range(30, 70);
        else if (LoaderBorder.roomCount < 30)
            luckPercent = Random.Range(30, 50);
        else
            luckPercent = Random.Range(10, 50);
    }

    public void upButtonPressed()
    {
        if(coinsSpent < PlayerStatus.coinCount && luckPercent + 5 <= 100)
        {
            coinsSpent++;
            luckPercent += 5;
        }

        updatePercent();
    }

    public void downButtonPressed()
    {
        if(coinsSpent > 0)
        {
            coinsSpent--;
            luckPercent -= 5;
        }

        updatePercent();
    }

    private void updatePercent()
    {
        luckyPercent.GetComponent<TextMeshProUGUI>().text = luckPercent.ToString() + "%";
        unluckyPercent.GetComponent<TextMeshProUGUI>().text = (100 - luckPercent).ToString() + "%";
        currentCoins.GetComponent<TextMeshProUGUI>().text = coinsSpent.ToString();
    }


    public void rollButtonPressed()
    {
        int roll = Random.Range(0, 100);

        if (roll <= luckPercent) //rolled something good
        {
            pickGoodBuff();
        }
        else //rolled something bad
        {
            pickBadBuff();
        }

        PlayerStatus.subtractCoins(coinsSpent);
    }

    private void pickGoodBuff()
    {
        int roll = Random.Range(1, PlayerStatus.NUMBER_OF_BUFFS + 1);

        PlayerStatus.setItem((PlayerStatus.Item)roll);
        luckyItem.sprite = sprites[roll];

        lucky.SetActive(true);
        chestUI.SetActive(false);
    }

    private void pickBadBuff()
    {
        int roll = Random.Range(PlayerStatus.NUMBER_OF_BUFFS + 1, PlayerStatus.NUMBER_OF_BUFFS + PlayerStatus.NUMBER_OF_DEBUFFS + 1);

        PlayerStatus.setItem((PlayerStatus.Item)roll);

        unlucky.SetActive(true);
        chestUI.SetActive(false);
    }

    public void ToggleChestMenu()
    {
        Time.timeScale = 0f;
        chestUI.SetActive(true);
    }

    public void ResumeGame()
    {
        chestUI.SetActive(false);
        lucky.SetActive(false);
        unlucky.SetActive(false);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
