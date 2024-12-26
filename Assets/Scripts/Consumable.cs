using UnityEngine;

public class Consumable : Item
{

    public Consumable(string itemName, string itemType, Sprite sprite, int itemID) : base(itemName, itemType, sprite, itemID)
    {
       
    }

    public void consume()
    {
        Debug.Log("Consume Item");
    }


}