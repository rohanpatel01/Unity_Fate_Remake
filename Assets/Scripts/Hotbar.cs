using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlotButton : MonoBehaviour
{
    List<GameObject> slots = new List<GameObject>();
    GameObject selectedSlot;
    Color DEFAULT_COLOR;
    Color SELECT_SLOT_COLOR;
    GameObject previouslySelectedSlot;

    void Start()
    {
        SELECT_SLOT_COLOR.r = 0;
        SELECT_SLOT_COLOR.g = 1.0f;
        SELECT_SLOT_COLOR.b = 1.0f;
        SELECT_SLOT_COLOR.a = 0.1961f;

        DEFAULT_COLOR.r = 1.0f;
        DEFAULT_COLOR.g = 1.0f;
        DEFAULT_COLOR.b = 1.0f;
        DEFAULT_COLOR.a = 0.1961f;

        int childCount = this.gameObject.transform.childCount;
        Debug.Log(childCount);
        foreach (Transform child in transform)
        {
            slots.Add(child.gameObject);
        }
        selectedSlot = slots[0];
        GameObject borderGameObject = selectedSlot.transform.GetChild(0).transform.gameObject;
        GameObject colorGameObject = borderGameObject.transform.GetChild(0).transform.gameObject;
        colorGameObject.GetComponent<Image>().color = SELECT_SLOT_COLOR;

        previouslySelectedSlot = colorGameObject;
    }

    void Update()
    {
        handleInput();
    }

    void handleInput()
    {  

        for (int i = 1; i <= 8; i++)
        {
            KeyCode key = KeyCode.Alpha0 + i;

            if (Input.GetKeyUp(key))
            {
                GameObject slotGameObject = slots[i - 1];
                GameObject borderGameObject = slotGameObject.transform.GetChild(0).transform.gameObject;
                GameObject colorGameObject = borderGameObject.transform.GetChild(0).transform.gameObject;

                colorGameObject.GetComponent<Image>().color = SELECT_SLOT_COLOR;

                previouslySelectedSlot.GetComponent<Image>().color = DEFAULT_COLOR;
                previouslySelectedSlot = colorGameObject;
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Pressed enter");
        }
    }
}
