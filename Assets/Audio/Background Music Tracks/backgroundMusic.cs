using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
 
    }


    // this will play globally and won't be destroyed after changing scene
    private static backgroundMusic instance = null;
    public static backgroundMusic Instance
    {
        get { return instance; }
    }
    // Awake is called when backgroundMusic is created
    private void Awake()
    {
         if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
         else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}



// original code will restart the theme music everytime 
// the scene changes
/*
    public AudioClip MusicClip;
    public AudioSource BackgroudMusic;

    // Start is called before the first frame update
    void Awake()
    {
        BackgroudMusic.clip = MusicClip;
        BackgroudMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 */
