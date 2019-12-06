using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raptor_Level : MonoBehaviour
{
    //loads the Raptor Scene
   public void LoadRaptorScene()
    {
        SceneManager.LoadScene("RaptorDiagnose");
    }
}
