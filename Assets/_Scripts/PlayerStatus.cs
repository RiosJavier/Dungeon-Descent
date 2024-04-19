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

        currentItem = Item.ROPE;
        
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
                break;
            case Item.DAMAGE_MULT:
                //damage logic
                break;
            //we don't have a "none" check since nothing happens
        }

        if (isInverted && roomNumItemGrabbed + 2 == LoaderBorder.roomCount)
        {
            isInverted = false;
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

    private void activateInvertedControls()
    {
        isInverted = true;
        roomNumItemGrabbed = LoaderBorder.roomCount;
    }
}
