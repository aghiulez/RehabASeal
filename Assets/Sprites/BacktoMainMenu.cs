using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void backtoMain()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
