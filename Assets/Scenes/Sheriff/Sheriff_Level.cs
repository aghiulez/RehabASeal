using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sheriff_Level : MonoBehaviour
{
    //loads the Roma Scene
   public void LoadSheriffScene()
    {
        SceneManager.LoadScene("SheriffDiagnose");
    }
}
