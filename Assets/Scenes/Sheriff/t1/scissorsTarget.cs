using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class scissorsTarget : MonoBehaviour, IPointerEnterHandler
{
    public GameObject clip_board;
    public GameObject scissors;
    public Image entagled_bag;

    public void play_clipboard()
    {
        clip_board.GetComponent<Animator>().SetBool("play", true);
        StartCoroutine(hide_clipboard());
    }

    IEnumerator hide_clipboard()
    {
        yield return new WaitForSeconds(3);
        clip_board.GetComponent<Animator>().Play("hide_clipboard");

    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        if (scissorsDrag.itemBeingDragged != null)
        {
            scissors.GetComponent<Animator>().enabled = false;

            GetComponent<Animator>().enabled = false;
            //changes the transparency of the target to 0; its defualt state 
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 0;
            img.color = c;

            scissorsDrag.onTarget = true;
            entagled_bag.enabled = false;

            play_clipboard();

            // scissor SE
            FindObjectOfType<AudioManager>().Play("scissor");
        }
    }



}
