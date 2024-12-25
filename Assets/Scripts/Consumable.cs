using UnityEngine;

public class Consumable : Item
{

    public Consumable(string itemName, string itemType, Sprite sprite) : base(itemName, itemType, sprite)
    {
       
    }

    public void consume()
    {
        Debug.Log("Consume Item");
    }


}