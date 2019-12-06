using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class mmag_drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //game object that is being dragged
    public static GameObject itemBeingDragged;
    //stores the start position of the game object
    Vector3 startPosition;
    //stores the parent of the game object
    Transform startParent;
    //references clipboard game object
    public GameObject clip_board;

    public GameObject neck_target;

    //references instructions game object
    public GameObject Instruction_texts;


    public static bool wrongAnswer;



    //plays clip board animation
    public void play_clipboard()
    {
        Animator anim = clip_board.GetComponent<Animator>();
        anim.SetBool("play", true);

    }

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
        //Vector3 screenPoint = Input.mousePosition;
        //screenPoint.z = 100.0f;
        //transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        //position of game object follows mouse position 
        transform.position = eventData.position;

        //if user hasn't hovered over flipper, play flipper target help
        if (mmag_target.shoulder == false)
        {
            neck_target.GetComponent<Animator>().SetBool("targetHelp", true);
        }
        else if (mmag_target.shoulder)
        {
            Instruction_texts.gameObject.GetComponent<Text>().text = "Record your observations of Mimi on the clipboard.";
            play_clipboard();
        }



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

    public void Start()
    {
        wrongAnswer = false;
    }

    public void Update()
    {

        if (wrongAnswer)
        {
            Instruction_texts.gameObject.GetComponent<Text>().text = "Not Quite. Try Again.";
        }
    }

}
