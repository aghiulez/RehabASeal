using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class xSubmitControl : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject clipboard;
    public GameObject instructions;

    //plays the hide clipboard animation and changes the scene 
    IEnumerator hide_clipboard()
    {
        clipboard.GetComponent<Animator>().Play("hide_clipboard");
        yield return new WaitForSeconds(3);

    }

    IEnumerator change_scene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("RaptorDiagnose3");

    }

    //used to determine if takes user to next process or the same one
    public void notice()
    {
        int index = dropdown.GetComponent<Dropdown>().value;

        if (index == 2)
        {
            StartCoroutine(hide_clipboard());
        }
        else if(index != 0)
        {
            instructions.gameObject.GetComponent<Text>().text = "Not Quite. Try Again.";
            StartCoroutine(change_scene());
        }

    }


}
