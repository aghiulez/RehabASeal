﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class creamTrail : MonoBehaviour, IPointerEnterHandler
{
    //used to increase counter first time it enters target
    bool slot;

    public void OnPointerEnter(PointerEventData eventData)
    {



        if (creamDrag.itemBeingDragged != null)

        {
            if (!slot)
            {
                creamDrag.counter++;

            }
            slot = true;

            //makes trail visible
            Image img = GetComponent<Image>();
            Color c = img.color;
            c.a = 255;
            img.color = c;
        }

    }

    public void Start()
    {
        slot = false;
    }

}
