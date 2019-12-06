using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class magDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //game object that is being dragged
    public static GameObject itemBeingDragged;
    //stores the start position of the game object
    Vector3 startPosition;
    //stores the parent of the game object
    Transform startParent;
    //references clipboard game object
    public GameObject clip_board;

    public GameObject mouth_target;
    public GameObject flipper_target;

    //references instructions game object
    public GameObject Instruction_texts;



    // references raptor to change animations
    public GameObject Raptor;
    // references large righthand Magnified zoom
    public Image MagGlassZoom;
    public Image MagGlassZoomFlipper;


    public Image ZoomShade;
    public Image ZoomShadeFlipper;


    public int mouthVisit = 0;
    public int flipperVisit = 0;

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
        //position of game object follows mouse position 
        transform.position = eventData.position;

        if (mouthTarget.mouth)
        {

            Raptor.GetComponent<Animator>().Play("RaptorMouthBlink(2)");  // opens mouth --> continues blink
            MagGlassZoom.enabled = true;                                  // the zoomed in Magnifying glass is now enabled to be seen
            ZoomShade.enabled = true;                                     // the shade for the magnifying glass is also enabled to be seen
            mouthVisit += 1; // increment visit of mouth
        }

        if (flipperTarget.flipper)
        {

            MagGlassZoomFlipper.enabled = true;
            ZoomShadeFlipper.enabled = true;
            flipperVisit += 1; // increment visit of flipper

        }

        if (!mouthTarget.mouth)
        {
            MagGlassZoom.enabled = false;
            Raptor.GetComponent<Animator>().Play("RaptorBlink(scene1)");
            MagGlassZoom.enabled = false;
            ZoomShade.enabled = false;
        }


        if (!flipperTarget.flipper)
        {

            MagGlassZoomFlipper.enabled = false;
            ZoomShadeFlipper.enabled = false;

        }

        //if user hasn't hovered over flipper, play flipper target help
        if (flipperTarget.flipper == false) {
            flipper_target.GetComponent<Animator>().SetBool("targetHelp", true);
        }

        //if user has hovered over flipper but not the mouth, play mouth target help
        if (flipperTarget.flipper == true && mouthTarget.mouth == false)
        {
            mouth_target.GetComponent<Animator>().SetBool("targetHelp", true);
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

        // Raptor SE
        //FindObjectOfType<AudioManager>().Play("RaptorSound");

    }

    public void Start()
    {
        wrongAnswer = false;
    }

    public void Update()
    {
       
        //if magnifying glass hovered over both mouth and flipper, play clipboard animation
        //if(mouthTarget.mouth && flipperTarget.flipper)
        if (mouthVisit > 0 && flipperVisit > 0)
        {
            Instruction_texts.gameObject.GetComponent<Text>().text = "Record your observations of Raptor on the clipboard.";

             
            play_clipboard();
        }
        if (wrongAnswer)
        {
            Instruction_texts.gameObject.GetComponent<Text>().text = "Not Quite. Try Again.";
        }
    }

}
