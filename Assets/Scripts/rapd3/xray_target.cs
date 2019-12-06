using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class xray_target : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //references the instructions panel 
    public GameObject instructions;
    public GameObject Raptor;
    public GameObject clip_board;
    public GameObject target;

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

    public void play_clipboard()
    {
        Animator cb = clip_board.GetComponent<Animator>();
        cb.SetBool("play", true);
    }


    public void OnDrop(PointerEventData eventData)
    {
        //if we dont have an item in the target, accept new item
        if (!item)
        {
            //gets the item being dragged, sets parent to the current transform
            xray_drag.itemBeingDragged.transform.SetParent(transform);
           
            //stops animation from playing 
            GetComponent<Animator>().enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            Raptor.GetComponent<Animator>().Play("RaptorXRayBlink");
            target.GetComponent<Image>().enabled = false;

            // scanning SE
            FindObjectOfType<AudioManager>().Play("scanning");

            instructions.gameObject.GetComponent<Text>().text = "Record your observations of Raptor on the clipboard.";
            play_clipboard();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(xray_drag.itemBeingDragged != null)
        {
            Raptor.GetComponent<Animator>().Play("RaptorArmRaisedBlink");
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (xray_drag.itemBeingDragged != null)
        {
            Raptor.GetComponent<Animator>().Play("RaptorBlink(scene1)");
        }
    }


}