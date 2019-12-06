using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class magSubmitManager : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject clipboard;



    //plays the hide clipboard animation and changes the scene 
    IEnumerator hide_clipboard()
    {
        clipboard.GetComponent<Animator>().Play("hide_clipboard");
        yield return new WaitForSeconds(3);
    }

    IEnumerator change_scene()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SheriffDiagnose2");

    }


    //used to determine if takes user to next process or the same one
    public void notice()
    {
        int index = dropdown.GetComponent<Dropdown>().value;

        if (index == 2)
        {
            StartCoroutine(hide_clipboard());
        }
        else if (index != 0)            // index 0 should not be an option at all (cant submit with '--')
        {
            magnifyDrag.wrongAnswer = true;
            StartCoroutine(change_scene());
        }

    }


}
