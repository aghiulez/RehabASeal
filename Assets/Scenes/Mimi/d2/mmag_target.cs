using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class mmag_target : EventTrigger, IDropHandler
{

    public static bool shoulder = false;


    public override void OnPointerExit(PointerEventData eventData)
    {

        // fix this area because if both are not set to true ...
        // we'll next get the clipboard animation to pop up !

        shoulder = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {


        //if the user is dragging the magnifying glass
        if (mmag_drag.itemBeingDragged != null)
        {
            shoulder = true;



            GetComponent<Animator>().enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;
        }


    }



}
