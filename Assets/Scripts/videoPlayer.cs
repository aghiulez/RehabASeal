using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour
{
  
   IEnumerator play_video()
    { 

        // pause the background music
//        FindObjectOfType<AudioManager>().pauseBackgroundMusic = true;

        yield return new WaitForSeconds(1.2f);

        GetComponent<VideoPlayer>().Play();

    }
    void Start()
    {
        //StartCoroutine(play_video());
    }
}
