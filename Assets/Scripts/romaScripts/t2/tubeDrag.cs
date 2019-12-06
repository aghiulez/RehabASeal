using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class tubeDrag : MonoBehaviour
{
    //game object that is being dragged
    public static GameObject itemBeingDragged;
    //stores the start position of the game object
    Vector3 startPosition;
    //stores the parent of the game object
    Transform startParent;
    //used to start animation
    public static bool slot;

    public void Start()
    {
        itemBeingDragged = gameObject;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }




}
