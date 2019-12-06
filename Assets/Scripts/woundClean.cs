using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class woundClean : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //game object that is being dragged
    public static GameObject itemBeingDragged;
    public GameObject clip_board;
    //stores the start position of the game object
    Vector3 startPosition;
    //stores the parent of the game object
    Transform startParent;

    //used to determine if all trails are visible 
    public static bool done;
    public static int counter;

    public Sprite cottonBall;
    //default sprite 
    public Sprite cream;

    //array all targets used
    public GameObject[] targets;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //sets item being dragged to the current game object
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        //sets the start parent of the object
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(transform.root);

    }

    public void OnDrag(PointerEventData eventData)
    {
        //position of game object follows mouse position 
        transform.position = eventData.position;
        //changes sprite when user drags tool 
        GetComponent<Image>().sprite = cottonBall;
        //changes size of the tool 
        //GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemBeingDragged = null;
        //changes sprite to default sprite
        GetComponent<Image>().sprite = cream;


        //snaps object back to original slot if not over the target slot 
        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // cream rubbing SE
        FindObjectOfType<AudioManager>().Play("rubbingCream");


    }


    IEnumerator play_clipboard()
    {
        clip_board.GetComponent<Animator>().SetBool("play", true);
        //makes trail not visible 
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }

        StartCoroutine(hide_clipboard());
    }

    IEnumerator hide_clipboard()
    {
        yield return new WaitForSeconds(3);
        clip_board.GetComponent<Animator>().Play("hide_clipboard");

    }

    void Start()
    {

        done = false;
        counter = 0;
    }

    void Update()
    {
        //checks if all trail is complete
        if (counter == 3 && !done)
        {
            done = true;
            StartCoroutine(play_clipboard());
        }
    }

}
