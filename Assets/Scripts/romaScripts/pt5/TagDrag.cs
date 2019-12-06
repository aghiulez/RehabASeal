using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class TagDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //game object that is being dragged
    public static GameObject itemBeingDragged;
    //stores the start position of the game object
    Vector3 startPosition;
    //stores the parent of the game object
    Transform startParent;


    //references target gameobject
    public GameObject target;



    public void OnBeginDrag(PointerEventData eventData)
    {
        //sets item being dragged to the current game object
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        //sets the start parent of the object
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(transform.root);

        //starts the target help animation 
        target.GetComponent<Animator>().SetBool("targetHelp", true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //position of game object follows mouse position 
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemBeingDragged = null;


        //snaps object back to original slot if not over the target slot 
        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;


    }



}
