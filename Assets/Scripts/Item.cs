using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    
    public string itemName;
    public Sprite sprite;
    public string itemType;

    public Item (string itemName, string itemType, Sprite sprite)
    {
        this.itemName = itemName;
        this.itemType = itemType;
        this.sprite = sprite;
    }

    public string getItemName()
    {
        return itemName;
    }

    public string getItemType()
    {
        return itemType;
    }

    public void setItemName(string name)
    {
        itemName = name;
    }

    public void setItemType(string type)
    {
        itemType = type;
    }

}