using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public enum Item
    {
        NONE, ROPE, COIN_MULT, DAMAGE_MULT
    }

    //the transform of the player
    //public Transform playerTransform;

    //Permanent multipliers that can be increased by the shopkeeper
    public int PERMANENT_DAMAGE_MULTIPLIER;
    public int PERMANENT_COIN_MULTIPLIER;

    //Temporary Buffs
    public int tempDamageMult;
    public int tempCoinMult;

    //Num of tempCoinMult currently in use 
    

    //Debuffs
    public int damageDebuff;
    public static bool isInverted;

    //Current Item
    private static Item currentItem;

    //time when item was grabbed.
    public int roomNumItemGrabbed;


    // Start is called before the first frame update
    void Start()
    {
        PERMANENT_DAMAGE_MULTIPLIER = 1;
        PERMANENT_COIN_MULTIPLIER = 1;

        damageDebuff = 0;

        roomNumItemGrabbed = 0;
        
        tempDamageMult = 1;
        tempCoinMult = 1;

        isInverted = false;

        currentItem = Item.NONE;

        ////TEST CODE: IF YOU WANT TO TEST YOUR STATUS, JUST CHANGE
        ////"currentItem" TO BE WHAT YOU WANT TO TEST!!!
        ////EX) currentItem = Item.ROPE;

        currentItem = Item.COIN_MULT;
        CoinController.tempCoinMultiplierNum++;
        //Whenever the player is assigned the coin multiplier powerup,
        //The CoinController.tempCoinMultiplierNum must increase by 1 (this will go in the treasure chest code perhaps)
        
        //////////////
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentItem)
        {
            case Item.ROPE:
                //rope logic
                
                break;
            case Item.COIN_MULT:
                //coin logic
                roomNumItemGrabbed = LoaderBorder.roomCount;
                if (LoaderBorder.roomCount == roomNumItemGrabbed + 2)
                {   
                    CoinController.tempCoinMultiplierNum--; 
                    currentItem = Item.NONE;
                }
                break;
            case Item.DAMAGE_MULT:
                //damage logic
                break;
            //we don't have a "none" check since nothing happens
        }
    }

    public static void setItem(Item i)
    {
        currentItem = i;
    }

    public static Item getItem()
    {
        return currentItem;
    }

    /*public static void changeLocation(Transform t)
    {
        
    }*/
}
