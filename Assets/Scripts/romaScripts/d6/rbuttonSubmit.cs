using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rbuttonSubmit : MonoBehaviour
{
    //references buttons
    public Button button1, button2, button3;
    //references title text
    public Text title;

    public GameObject diagnostics;

    void Start()
    {
        button1.onClick.AddListener(() => Wrapper("b1"));
        button2.onClick.AddListener(() => Wrapper("b2"));
        button3.onClick.AddListener(() => Wrapper("b3"));
    }

    //wrapper function used to call other functions
    public void Wrapper(string b_name)
    {
        switch (b_name)
        {
            case "b1": StartCoroutine(button1_action()); break;
            case "b2": StartCoroutine(button2_action()); break;
            case "b3": StartCoroutine(button3_action()); break;
        }

    }

    IEnumerator button1_action()
    {
        //disables all buttons
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        //changes the color of button to red 
        button1.GetComponent<Image>().color = new Color32(217, 69, 70, 255);
        title.text = "Oops. Try Again!";
        yield return new WaitForSeconds(3);
        title.text = "Make your Diagnosis";
        //changes color of buttont to default
        button1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //enables all buttons
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
    }

  
    IEnumerator button2_action()
    {
        //disables all buttons
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        button2.GetComponent<Image>().color = new Color32(217, 69, 70, 255);
        title.text = "Oops. Try Again!";
        yield return new WaitForSeconds(3);
        title.text = "Make your Diagnosis";
        button2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //enables all buttons
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;

    }

    IEnumerator button3_action()
    {
        //disables all buttons
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        //changes button color to green 
        button3.GetComponent<Image>().color = new Color32(98, 181, 93, 255);
        title.text = "Good Job!";
        yield return new WaitForSeconds(2);
        diagnostics.GetComponent<Animator>().SetBool("hide", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("RomaTreatment1");
    }
}
