using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class wrapTarget : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions;
    public Animator anim;
    public GameObject clip_board;
    public GameObject wrap;
    public Sprite raptorWrap;
    public GameObject Raptor;

    public void play_clipboard()
    {
        Animator cb = clip_board.GetComponent<Animator>();
        cb.SetBool("play", true);
        StartCoroutine(hide_clipboard());
    }

    IEnumerator hide_clipboard()
    {
        yield return new WaitForSeconds(3);
        Animator cb = clip_board.GetComponent<Animator>();
        cb.Play("hide_clipboard");

    }
    IEnumerator changeRaptorSprite()
    {
        yield return new WaitForSeconds(1);
        Raptor.GetComponent<Image>().sprite = raptorWrap;
    }

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
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            //gets the item being dragged, sets parent to the current transform
            wrapDrag.itemBeingDragged.transform.SetParent(transform);
            wrap.GetComponent<Animator>().Play("Wrap");
            StartCoroutine(changeRaptorSprite());

            //hides the instructions panel
            Instructions.gameObject.SetActive(false);
            play_clipboard();

            // bandaging SE
            FindObjectOfType<AudioManager>().Play("bandaging");
        }
    }




}