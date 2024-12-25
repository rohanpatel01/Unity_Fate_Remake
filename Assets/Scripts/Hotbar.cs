using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    
    public List<GameObject> slots = new List<GameObject>();
    Color DEFAULT_COLOR;
    Color SELECT_SLOT_COLOR;
    int INDEX_SLOT_OFFSET = 1;
    GameObject currentlySelectedSlot;
    GameObject previouslySelectedSlot;

    void Start()
    {   

        SELECT_SLOT_COLOR.r = 0;
        SELECT_SLOT_COLOR.g = 1.0f;
        SELECT_SLOT_COLOR.b = 1.0f;
        SELECT_SLOT_COLOR.a = 1f;

        DEFAULT_COLOR.r = 1.0f;
        DEFAULT_COLOR.g = 1.0f;
        DEFAULT_COLOR.b = 1.0f;
        DEFAULT_COLOR.a = 0.5f;

        foreach (Transform child in transform)
        {
            GameObject slotObject = child.gameObject;
            GameObject borderGameObject = slotObject.transform.GetChild(0).transform.gameObject;
            GameObject colorGameObject = borderGameObject.transform.GetChild(0).transform.gameObject;
            GameObject itemGameObject = colorGameObject.transform.GetChild(0).transform.gameObject;
            slots.Add(itemGameObject);
        }

        currentlySelectedSlot = slots[0];
        currentlySelectedSlot.GetComponentInParent<Image>().color = SELECT_SLOT_COLOR;
        previouslySelectedSlot = currentlySelectedSlot;
    }

    void Update()
    {
        handleInput();
    }

    void handleInput()
    {  
        if (Input.GetKeyUp(KeyCode.Return))
        {
            currentlySelectedSlot.GetComponent<Consumable>().consume();
        }

        for (int i = 1; i <= 8; i++)
        {
            
            KeyCode key = KeyCode.Alpha0 + i;

            if (Input.GetKeyUp(key))
            {
                currentlySelectedSlot = slots[i - INDEX_SLOT_OFFSET];

                currentlySelectedSlot.GetComponentInParent<Image>().color = SELECT_SLOT_COLOR;
                previouslySelectedSlot.GetComponentInParent<Image>().color = DEFAULT_COLOR;

                previouslySelectedSlot = currentlySelectedSlot;
            }
        }
    }
}
