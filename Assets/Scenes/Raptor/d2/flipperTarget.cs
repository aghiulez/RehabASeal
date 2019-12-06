using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class flipperTarget : EventTrigger
{
    //used to check if magnifying glass has been over flipper
    public static bool flipper = false;


    public override void OnPointerExit(PointerEventData eventData)
    {
        flipper = false;
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        //if the user is dragging the magnifying glass
        if (magDrag.itemBeingDragged != null)
        {
            flipper = true;


            GetComponent<Animator>().enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

        }

    }
}
