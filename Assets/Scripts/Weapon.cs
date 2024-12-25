using UnityEngine;

public class Weapon : Item {

    public int attackDamage;

    public Weapon(string itemName, string itemType, int attackDamage, Sprite sprite) : base(itemName, itemType, sprite)
    {
        this.attackDamage = attackDamage;
    }

    

}