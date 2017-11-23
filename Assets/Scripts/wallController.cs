using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class wallController : MonoBehaviour 
{

//	VideoPlayer wallObj1_videoPlayer;
//	VideoPlayer wallObj2_videoPlayer;
//	VideoPlayer wallObj3_videoPlayer;
//	VideoPlayer wallObj4_videoPlayer;
//	VideoPlayer.EnableAudioTrack = true;

	string[] playList = new string[4];
	static public VideoPlayer[] videoScreen = new VideoPlayer[4];
	BoxCollider[] trigger = new BoxCollider[4];
//	bool[] VideoPlayerListFinished = new bool[3];
	static public int currentPlaying = 0;

	// Use this for initialization
	void Start () 
	{
			
		videoScreen [0] = GameObject.Find ("Wall000").GetComponent<VideoPlayer> ();
		videoScreen [1] = GameObject.Find ("Wall001").GetComponent<VideoPlayer> ();
		videoScreen [2] = GameObject.Find ("Wall002").GetComponent<VideoPlayer> ();
		videoScreen [3] = GameObject.Find ("Wall003").GetComponent<VideoPlayer> ();

		trigger [0] = GameObject.Find ("TriggerBox00").GetComponent<BoxCollider> ();
		trigger [1] = GameObject.Find ("TriggerBox01").GetComponent<BoxCollider> ();
		trigger [2] = GameObject.Find ("TriggerBox02").GetComponent<BoxCollider> ();
		trigger [3] = GameObject.Find ("TriggerBox03").GetComponent<BoxCollider> ();

//		VideoScreen[0].source = VideoSource.Url;
//		VideoScreen[1].source = VideoSource.Url;
//		VideoScreen[2].source = VideoSource.Url;
//		VideoScreen[3].source = VideoSource.Url;

		//for (int i = 0; i < playList.Length; i++) {
			//playList [i] = "file://" + Application.dataPath + "/Resources/videos/" + i + ".mp4";

			playList [0] = "file://" + Application.dataPath + "/Resources/videos/00.mp4";
			playList [1] = "file://" + Application.dataPath + "/Resources/videos/01.mp4";
			playList [2] = "file://" + Application.dataPath + "/Resources/videos/02.mp4";
			playList [3] = "file://" + Application.dataPath + "/Resources/videos/00.mp4";
		//}
		videoScreen [0].url = playList [0];

		videoScreen [0].Prepare ();
		//videoScreen [0].Play ();
		currentPlaying = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (videoScreen[currentPlaying].isPrepared&&!videoScreen[currentPlaying].isPlaying) 
		{
			// stop current videoscreen, make it black
			videoScreen [currentPlaying].Stop ();
			// initial a random number, play next clip in random screen
//			int randomScreen = Random.Range (0, playList.Length);

			// go to next clip
			currentPlaying++;
			if (currentPlaying >= playList.Length) 
			{
				currentPlaying = 0;
			}

//			WaitForSeconds waitTime = new WaitForSeconds(5);
//			yield return waitTime;
			videoScreen [currentPlaying].url = playList [currentPlaying];
			videoScreen [currentPlaying].Prepare ();
			videoScreen [currentPlaying].Play ();
		}			
	}
		
/*
	void OnMouseDown()
	{
		//GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
		m_ObjectCollider.isTrigger = true;
		//Output to console the GameObject’s trigger state
		Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
	}
*/		
}

 