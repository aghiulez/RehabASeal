using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class rglucose_target : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions;
    //references blood container game object
    public GameObject blood_container;

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
            GetComponent<Animator>().enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            //gets the item being dragged, sets parent to the current transform
            rglucose_drag.itemBeingDragged.transform.SetParent(transform);
            //hides the instructions panel
            Instructions.gameObject.SetActive(false);

            blood_container.GetComponent<Animator>().SetBool("tilt", true);

            // blood dripping SE with 2sed delay
            FindObjectOfType<AudioManager>().Play("drippingBlood", 2);
        }
    }




}