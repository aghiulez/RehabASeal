using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PTWeightTarget : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions_text;
    public Animator anim;
    public GameObject target;
    public GameObject weight;
    public string animName = "";
    public Text level_title;

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
            PTWeightDrag.itemBeingDragged.transform.SetParent(transform);
            weight.GetComponent<Animator>().Play(animName);

            StartCoroutine(update_bubble());
            // seal SE
            FindObjectOfType<AudioManager>().Play("sealSound");
        }
    }

    IEnumerator update_bubble()
    {
        yield return new WaitForSeconds(1);
        Instructions_text.gameObject.GetComponent<Text>().text = "Healthy weight!";
        level_title.text = "Time for release!";

    }


}