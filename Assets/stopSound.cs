using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopSound : MonoBehaviour
{
    // Start is called before the first frame update
    public void StopSound()
    {
        FindObjectOfType<AudioManager>().pauseBackgroundMusic = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
