using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class stepOn : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public string[] playList = new string[11];
	public int currentPlaying = 0;

	//execute order of the event functions

	void Start()
	{
		//always called before Start
		//only when game object is enabled

		//load all videos and creat the playlist
		for (int i = 0; i < playList.Length; i++)
		{
			playList [i] = "file://" + Application.dataPath + "/Resources/Videos/" + i + ".mp4";
		}

		videoPlayer.playOnAwake = false;

		//videoPlayer.source = VideoSource.Url;
		videoPlayer.url = playList [currentPlaying];
		videoPlayer.Prepare ();
		videoPlayer.Play();
		Debug.Log("prepared?" + videoPlayer.isPrepared);


//		videoPlayer.SetTargetAudioSource (videoPlayer.url);
	}

	// void Start()
	// {
	// 	//called before any frame are executed
	// 	//use for varible loading
	// 	Debug.Log("prepared?" + videoPlayer.isPrepared);
	// 	Debug.Log(videoPlayer.isPlaying);
	// }

	void Update()
	{
		//most game code
		//called per frame
		//frequent use of Time.deltaTime

		if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
		{
			videoPlayer.Play ();
			Debug.Log("triggered");
		}

//		if (Input.GetKeyUp (KeyCode.Space))
//			videoPlayer.Play ();

//		if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
//			// go to next clip
//			currentPlaying++;

		videoPlayer.loopPointReached += VideoPlayer_loopPointReached;;

		if (currentPlaying >= playList.Length)
			currentPlaying = 0;

		videoPlayer.url = playList [currentPlaying];
		videoPlayer.Prepare ();

//		videoPlayer.SetTargetAudioSource (videoPlayer.url);
//		{
			 //initial a random number, play next clip in random screen
//						int randomScreen = Random.Range (0, playList.Length);
//						WaitForSeconds waitTime = new WaitForSeconds(5);
//						yield return waitTime;
//		}
	}

	void VideoPlayer_loopPointReached (VideoPlayer source)
	{
		currentPlaying++;
	}

	void LateUpdate()
	{
		//called per frame
		//only after Update() is called
	}

	void FixedUpdate ()
	{
		//physics based movement and calculations
		//not called on a per-frame basis
		//called only when needed
		//built in timer centered around performace stresses
		//if lagging, called multiple times per frame
		//otherwise, called around once per frame
		//no need to use Time.deltaTime
	}

	void OnTriggerEnter(Collider other)
	{
		videoPlayer.Play ();
	}

	void OnTriggerExit(Collider other)
	{
		videoPlayer.Stop ();
	}
}
