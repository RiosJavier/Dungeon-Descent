using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class PlayerStatus : MonoBehaviour
{
    public enum Item
    {
        NONE, 
        
        ROPE, COIN_MULT, INVINCIBLE, SHIELD, //BUFFS
        
        INSTAKILL, NO_DAMAGE, INV_CONTROLS //DEBUFFS
    }

    public static int NUMBER_OF_BUFFS = 4;
    public static int NUMBER_OF_DEBUFFS = 3;

    //the transform of the player
    //public Transform playerTransform;

    //Permanent multipliers that can be increased by the shopkeeper
    public static int PERMANENT_DAMAGE_MULTIPLIER;
    public static int PERMANENT_COIN_MULTIPLIER;
    public static int PERMANENT_HEALTH_BOOST;

    //Temporary Buffs
    public int tempDamageMult;
    public static int tempCoinMult;

    //Debuffs
    public static bool isInstakill;
    public static bool damageDebuff;
    public static bool isLimitedSight;
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
        PERMANENT_HEALTH_BOOST = 0; //BECAUSE NO HEARTS

        damageDebuff = false;

        roomNumItemGrabbed = -1;
        
        tempDamageMult = 1;
        tempCoinMult = 1;

        isInstakill = false;
        isLimitedSight = false;
        isInverted = false;

        setItem(Item.NONE);

        coinCount = 0;

        isInvincible = false;

        ////TEST CODE: IF YOU WANT TO TEST YOUR STATUS, JUST CALL
        ////"setItem(Item...) TO BE WHAT YOU WANT TO TEST!!
        ////EX) setItem(Item.ROPE);
        
        coinCount = 300;
        

        //////////////
    }

    // Update is called once per frame
    void Update()
    {
        // powerup logic
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
                case Item.INVINCIBLE:
                    removeInvincible(); break;
                default: 
                    //things that should go to default are items such as rope or shield.
                    break;
                //we don't have a "none" check since nothing happens
            }
        }

        // debuff logic
        if(roomNumItemGrabbed != -1 && roomNumItemGrabbed + 1 == LoaderBorder.roomCount){
            roomNumItemGrabbed = -1;
            switch (currentItem)
            {
                case Item.INSTAKILL:
                    //instakill logic
                    removeInstaKill();
                    break;
                case Item.NO_DAMAGE:
                    //no damage logic
                    removeDamageDebuff();
                    break;
                case Item.INV_CONTROLS:
                    //inverted controls logic
                    removeInvertedControls();
                    break;
            }
        }

        updateCoin();
    }

    public static void setItem(Item i)
    {
        currentItem = i;

        switch (currentItem)
        {
            case Item.NONE:
                roomNumItemGrabbed = -1; break;
            case Item.ROPE:
                break;
            case Item.COIN_MULT:
                addCoinMultiplier(); break;
            case Item.INVINCIBLE:
                addInvincible(); break;
            case Item.SHIELD:
                addShield(); break;
            case Item.INSTAKILL:
                addInstaKill(); break;
            case Item.NO_DAMAGE:
                addDamageDebuff(); break;
            case Item.INV_CONTROLS:
                addInvertedControls(); break;
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

    private static void addInstaKill()
    {
        isInstakill = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    private void removeInstaKill()
    {
        isInstakill = false;
        setItem(Item.NONE);
    }

    private static void addLimitedSight()
    {
        isLimitedSight = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    private void removeLimitedSight()
    {
        isLimitedSight = false;
        setItem(Item.NONE);
    }
    private static void addInvertedControls()
    {
        isInverted = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    private void removeInvertedControls()
    {
        isInverted = false;
        setItem(Item.NONE);
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

    public static void addShield()
    {   
        //Add shield logic
        HealthTracker.shield++;
        setItem(Item.NONE);
        //roomNumItemGrabbed = LoaderBorder.roomCount;   
    }

    public void updateCoin()
    {
        //Debug.Log("Coins: " + coinCount.ToString());
        coinText.text = "COINS: " + coinCount.ToString();
    }

    public static void addDamageDebuff()
    {
        damageDebuff = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }

    public static void removeDamageDebuff()
    {
        damageDebuff = false;
        setItem(Item.NONE);
    }
}   
