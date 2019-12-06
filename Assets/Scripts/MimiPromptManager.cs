using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MimiPromptManager : MonoBehaviour
{
    public void lastRehab()
    {
        SceneManager.LoadScene("MimiTreatment3.1");
    }

    public void goToStory()
    {
        SceneManager.LoadScene("MimiStory");
       
    }
}
