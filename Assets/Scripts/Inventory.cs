using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Inventory : MonoBehaviour
{
    public List<GameObject> inventorySlots = new List<GameObject>();
    private List<Item> itemList = new List<Item>();

    public List<int> isAvailable = new List<int>();
    public int nextAvailableSlotIndex;

    void Start()
    {
        nextAvailableSlotIndex = 0;

        foreach (Transform child in transform)
        {           
            inventorySlots.Add(child.gameObject);
        }
    }

    void Update()
    {
        
    }

    public void placeItemInInventory(GameObject item)
    {
        switch(item.GetComponent<Item>().itemType)
        {
            case "Weapon":

                inventorySlots[nextAvailableSlotIndex].GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
                Weapon weapon = item.GetComponent<Weapon>();
                itemList.Add( new Weapon(weapon.itemName, weapon.itemName, weapon.attackDamage, weapon.sprite));
                Debug.Log("Picked up weapon");
                break;

            case "Consumable":
                Debug.Log("Consumable");
                break;


        }



        Debug.Log("Item name: " + item.GetComponent<Item>().getItemName());
    }

}
