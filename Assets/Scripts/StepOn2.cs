using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StepOn2 : MonoBehaviour
{
	public VideoPlayer videoPlayer;
//	private AudioSource audioSource;
	public string[] playList = new string[11];
	public int currentPlayingVid = 0;

	// Use this for initialization
	void Start ()
	{
		//load all videos and creat the playlist
		for (int i = 0; i < playList.Length; i++)
		{
			playList [i] = "file://" + Application.dataPath + "/Resources/Videos/" + i + ".mp4";
		}
	}

	// Update is called once per frame
	void Update ()
	{
		videoPlayer.url = playList[currentPlayingVid];
		videoPlayer.Prepare ();
	}

	void OnTriggerEnter(Collider other)
	{
		videoPlayer.Play ();
	}

	void OnTriggerExit(Collider other)
	{
		videoPlayer.Stop ();
		currentPlayingVid = currentPlayingVid + 1;
	}
}
