using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

    // put all soundeffects in array
	public Sound[] sounds;


    public bool pauseBackgroundMusic = false;
    public bool backgroundMusicOn;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

        // put soundeffects into audio source as the game awake
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}

        // play background music as the program starts
        Play("BackgroundMusic");
        backgroundMusicOn = true;

    }

    void Update()
    {
        if (pauseBackgroundMusic == true)
        {
            Pause("BackgroundMusic");
            backgroundMusicOn = false;
        }
        else if (backgroundMusicOn == false && pauseBackgroundMusic == false)
        {
            Play("BackgroundMusic");
            backgroundMusicOn = true;
        }
    }

    private void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Play(string sound, ulong delay = 0)
    {
        // store the soundeffect that we found 
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        if (delay == 0)
        {
            s.source.Play();

        }
        else
        {
            s.source.PlayDelayed(delay);
        }
    }

    public void ChangeVolume(string sound, float volume)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = volume;
    }
}


// in other source code file
// use the following call to play soundeffect at the moment it should play
// FindObjectOfType<AudioManager>().Play("NAMEOFTHESOUNDEFFECT");