using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void BeginGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("SelectStoryScene");
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
