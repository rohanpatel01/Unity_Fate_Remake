using UnityEngine;

public class Weapon : Item {

    public int attackDamage;

    public Weapon(string itemName, string itemType, int attackDamage, Sprite sprite, int itemID) : base(itemName, itemType, sprite, itemID)
    {
        Debug.Log("Weapon constructor called on: " + itemName);
        this.attackDamage = attackDamage;
    }

    

}