using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class maskTarget : MonoBehaviour, IDropHandler
{
    //references the instructions panel 
    public GameObject Instructions;
    public Animator anim;
    public GameObject clip_board;
    public GameObject Raptor;
    public Sprite RaptorSleep;
    public GameObject mask;
    public GameObject sitScar;
    public GameObject layScar;

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

    IEnumerator raptor_sleep()
    {
        yield return new WaitForSeconds(4);
        Raptor.GetComponent<Animator>().enabled = false;
        mask.GetComponent<Image>().enabled = false;
        Raptor.GetComponent<RectTransform>().sizeDelta = new Vector2(886.5f, 587.6f);
        Raptor.GetComponent<Image>().sprite = RaptorSleep;
        sitScar.SetActive(false);
        layScar.SetActive(true);
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
            maskDrag.itemBeingDragged.transform.SetParent(transform);
            StartCoroutine(raptor_sleep());
            //hides the instructions panel
            Instructions.gameObject.SetActive(false);
            play_clipboard();

            // mask breathing SE
            FindObjectOfType<AudioManager>().Play("breathMask");
        }
    }




}