using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Inventory : MonoBehaviour
{
    public List<GameObject> inventorySlots = new List<GameObject>();

    public Dictionary<string, Dictionary<int, GameObject>> itemList = new Dictionary<string, Dictionary<int, GameObject>>();

    public List<int> isAvailable = new List<int>();
    public int nextAvailableSlotIndex;

    void Start()
    {
        itemList.Add("Weapon", new Dictionary<int, GameObject>());
        itemList.Add("Consumable", new Dictionary<int, GameObject>());

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
        if (nextAvailableSlotIndex < inventorySlots.Count)
        {
            // Change sprite of inventory slot
            inventorySlots[nextAvailableSlotIndex].GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
            nextAvailableSlotIndex++;

            switch(item.GetComponent<Item>().itemType)
            {
                case "Weapon":
                    itemList["Weapon"].Add(item.GetComponent<Weapon>().itemID, item);
                    break;

                case "Consumable":
                    itemList["Consumable"].Add(item.GetComponent<Weapon>().itemID, item);
                    break;
                
            }

            Destroy(item);

        } 
        else 
        {
            Debug.Log("You are overburdened");
        }
        
    }

}
