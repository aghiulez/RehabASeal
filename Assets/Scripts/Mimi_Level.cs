using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mimi_Level : MonoBehaviour
{
    //loads the Raptor Scene
   public void LoadMimiScene()
    {
        SceneManager.LoadScene("MimiDiagnose");
    }
}
