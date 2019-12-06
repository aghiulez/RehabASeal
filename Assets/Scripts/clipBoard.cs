using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clipBoard : MonoBehaviour
{
    //used to reference clipboard animation
    public Animator CLIPBOARD;
    //this variable is set in the inspector window 
    public string sceneName = "";

    public void change_scene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void hide_clipboard()
    {
        CLIPBOARD.Play("hide_clipboard");
    }
}
