using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions;
    public Animator anim;
    public GameObject target;
    public GameObject weight;
    public string weightAnimName = "";
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
            //stops animation from playing 
            anim.enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = target.GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            //gets the item being dragged, sets parent to the current transform
            draggable.itemBeingDragged.transform.SetParent(transform);
            //if object in target slot, change to true 
            weight.GetComponent<Animator>().Play(weightAnimName);
            //hides the instructions panel
            Instructions.gameObject.SetActive(false);

            // seal SE
            FindObjectOfType<AudioManager>().Play("sealSound");
        }
    }

   


}