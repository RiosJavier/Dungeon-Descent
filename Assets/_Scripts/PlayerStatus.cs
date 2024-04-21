using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public enum Item
    {
        NONE, 
        
        ROPE, COIN_MULT, DAMAGE_MULT, INVINCIBLE, //BUFFS
        
        INSTAKILL, NO_DAMAGE, LIMITED_SIGHT //DEBUFFS
    }

    public static int NUMBER_OF_BUFFS = 4;
    public static int NUMBER_OF_DEBUFFS = 3;

    //the transform of the player
    //public Transform playerTransform;

    //Permanent multipliers that can be increased by the shopkeeper
    public int PERMANENT_DAMAGE_MULTIPLIER;
    public static int PERMANENT_COIN_MULTIPLIER;

    //Temporary Buffs
    public int tempDamageMult;
    public static int tempCoinMult;

    //Debuffs
    public int damageDebuff;
    public static bool isInverted;

    //Current Item
    private static Item currentItem;

    //time when item was grabbed.
    private static int roomNumItemGrabbed;

    //invincible boolean
    public static bool isInvincible;

    //number of coins the player has
    public static int coinCount;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        PERMANENT_DAMAGE_MULTIPLIER = 1;
        PERMANENT_COIN_MULTIPLIER = 1;

        damageDebuff = 0;

        roomNumItemGrabbed = -1;
        
        tempDamageMult = 1;
        tempCoinMult = 1;

        isInverted = false;

        currentItem = Item.NONE;

        coinCount = 0;

        isInvincible = false;

        ////TEST CODE: IF YOU WANT TO TEST YOUR STATUS, JUST CHANGE
        ////"currentItem" TO BE WHAT YOU WANT TO TEST!!!
        ////EX) currentItem = Item.ROPE;

        setItem(Item.INVINCIBLE);
        //currentItem = Item.COIN_MULT;
        //roomNumItemGrabbed = LoaderBorder.roomCount;
        //tempCoinMult = 2;
        coinCount = 10;
        
        //////////////
    }

    // Update is called once per frame
    void Update()
    {
        if(roomNumItemGrabbed != -1 && roomNumItemGrabbed + 2 == LoaderBorder.roomCount){
            roomNumItemGrabbed = -1;
            switch (currentItem)
            {
                case Item.ROPE:
                    //rope logic
                    break;
                case Item.COIN_MULT:
                    //coin logic
                    removeCoinMultiplier();
                    break;
                case Item.DAMAGE_MULT:
                    //damage logic
                    break;
                case Item.INVINCIBLE:
                    removeInvincible(); break;
                //we don't have a "none" check since nothing happens
            }
        }

        if (isInverted && roomNumItemGrabbed + 1 == LoaderBorder.roomCount)
        {
            isInverted = false;
        }

        if (isInverted && roomNumItemGrabbed + 1 == LoaderBorder.roomCount)
        {
            isInverted = false;
        }

        updateCoin();
    }

    public static void setItem(Item i)
    {
        currentItem = i;

        switch (currentItem)
        {
            case Item.NONE:
                roomNumItemGrabbed = LoaderBorder.roomCount; break;
            case Item.ROPE:
                break;
            case Item.COIN_MULT:
                addCoinMultiplier(); break;
            case Item.INVINCIBLE:
                addInvincible(); break;
        }
    }

    public static Item getItem()
    {
        return currentItem;
    }

    private static void addCoinMultiplier()
    {
        tempCoinMult = 2;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    private void removeCoinMultiplier() { 
        tempCoinMult = 1;
        setItem(Item.NONE);
    }

    private static void addInvincible()
    {
        isInvincible = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    private static void removeInvincible()
    {
        isInvincible = false;
        setItem(Item.NONE);
    }

    private void activateInvertedControls()
    {
        isInverted = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    public static void addCoin()
    {
        coinCount += 1 * PERMANENT_COIN_MULTIPLIER * tempCoinMult;
        Debug.Log("coin Count == " + coinCount);
    }

    public static void subtractCoins(int coinsSpent)
    {
        coinCount -= coinsSpent;
    }

    public void updateCoin()
    {
        //Debug.Log("Coins: " + coinCount.ToString());
        coinText.text = "COINS: " + coinCount.ToString();
    }
}
