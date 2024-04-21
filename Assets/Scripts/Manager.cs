using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class Manager: MonoBehaviour
{
	public VideoPlayer _videoplayer;
	public string URL;

	void Start()
	{
	}

	public void Play_Video()
	{
		_videoplayer.url = URL;
		_videoplayer.Play();
	}
}