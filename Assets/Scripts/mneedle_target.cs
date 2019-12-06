using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mneedle_target : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions;
    public GameObject item
    {
        get
        {
            //If target has a child
            if (transform.childCount > 0)
            {
                //returns first child
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //if we dont have an item in the target, accept new item
        if (!item)
        {
            //stops target help animation from playing 
            GetComponent<Animator>().enabled = false;

            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            //gets the item being dragged, sets parent to the current transform
            mneedle_drag.itemBeingDragged.transform.SetParent(transform);

            //hides the instructions panel
            Instructions.gameObject.SetActive(false);
            //if object in target slot, change to true 
            mneedle_drag.slot = true;
            //hides the instructions panel
            Instructions.gameObject.SetActive(false);

            // needle pumping SE
            FindObjectOfType<AudioManager>().Play("pumpingNeedle");
        }
    }

}