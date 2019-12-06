using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class fluidsDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public static bool slot;

    public GameObject canvas;
    public GameObject fluid_tube;

    //references target gameobject
    public GameObject target;

    GameObject tube;

    //spawns tube sprite for user to drag
    public void SpawnTube(PointerEventData data)
    {
        tube = Instantiate(fluid_tube) as GameObject;
        tube.transform.SetParent(canvas.transform, false);
        tube.transform.position = data.position;
    }

    //destroys the sprite 
    public void killTube()
    {
        Destroy(tube);
    }

    //tube follows mouse 
    public void tubeFollow(PointerEventData data)
    {
        tube.transform.position = data.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //starts the target help animation 
        target.GetComponent<Animator>().SetBool("targetHelp", true);
        SpawnTube(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<Image>().enabled = false;
        tubeFollow(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!slot)
        {
            GetComponent<Image>().enabled = true;
            killTube();
        }

    }

    void Start()
    {
        slot = false;
    }

}
