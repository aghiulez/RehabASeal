using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roma_Level : MonoBehaviour
{
    //loads the Roma Scene
   public void LoadRomaScene()
    {
        SceneManager.LoadScene("RomaDiagnose");
    }
}
