using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToAnimalSelection : MonoBehaviour
{
    // Start is called before the first frame update



    public void BackUp()
    {
        SceneManager.LoadScene("MainMenuScene");
        FindObjectOfType<AudioManager>().pauseBackgroundMusic = false;
    }
}
