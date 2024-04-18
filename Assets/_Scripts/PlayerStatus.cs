using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public enum Item
    {
        NONE, ROPE, COIN_MULT, DAMAGE_MULT
    }

    //Permanent multipliers that can be increased by the shopkeeper
    public int PERMANENT_DAMAGE_MULTIPLIER;
    public int PERMANENT_COIN_MULTIPLIER;

    //Temporary Buffs
    public int tempDamageMult;
    public int tempCoinMult;

    //Debuffs
    public int damageDebuff;

    //Current Item
    public static Item currentItem;

    //time when item was grabbed.
    public int roomNumItemGrabbed;

    //images for all items
    public List<Image> statusIcons;

    // Start is called before the first frame update
    void Start()
    {
        PERMANENT_DAMAGE_MULTIPLIER = 1;
        PERMANENT_COIN_MULTIPLIER = 1;

        damageDebuff = 0;

        roomNumItemGrabbed = 0;
        
        tempDamageMult = 1;
        tempCoinMult = 1;

        currentItem = Item.NONE;

        ////TEST CODE
        currentItem = Item.ROPE;
        ////

        setIcon();
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
    }

    void setItem(Item i)
    {
        currentItem = i;

        setIcon();
    }

    void setIcon() //set the game icon to indicate what item is equipped.
    {
        switch (currentItem)
        {
            case Item.ROPE:
                
                break;
            case Item.COIN_MULT:
                //coin logic
                break;
            case Item.DAMAGE_MULT:
                //damage logic
                break;
            case Item.NONE:
                break;
        }
    }

    public static Item getIcon()
    {
        return currentItem;
    }
}
