using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

// start out as dark, random sound as hints, directional sounds
// link the enviroment lighting to the main colors in the video
// use the space as the canvas
// random video, random position of the screens
// everyone gets a different story
// the ending scene is bright, reborn, new world

	public class Video_trigger : MonoBehaviour {
	public RawImage image;
	public VideoClip videoToPlay;
	public VideoPlayer videoPlayer;
	//public VideoSource videoSource;
	public string[] playList = new string[6];
	public AudioSource audioSource;
	public int currentPlaying = 0;
	GameObject[] allTriggers;

	void Start () 
	{
		Application.runInBackground = true;

		// load all videos into playlist
		for (int i = 0; i < playList.Length; i++) 
		{
			playList [i] = "file://" + Application.dataPath + "/Resources/Videos/" + i + ".mp4";
		}

		allTriggers = GameObject.FindGameObjectsWithTag ("videotriggers");

		//start a coroutine task
//		StartCoroutine (loadVideo());
	}

	// Update is called once per frame
	void Update () {

//		allTriggers = GameObject.FindWithTag ("videotriggers").GetComponent<BoxCollider> ();
//		Debug.Log (allTriggers);

		if (videoPlayer.isPlaying) {
			foreach (GameObject pad in allTriggers) {
//				pad.SetActive (false);
			} 

			//diable the triggers until video finish;
//			allTriggers.enabled = (false);
//			Debug.Log("Disable: " + gameObject.name);
//			gameObject.GetComponent(videoPlayer).SetActive (false);
//			bool triggerStatus = gameObject.GetComponentInChildren(typeof(VideoClip)) as bool
		}
	}

	IEnumerator loadVideo()
	{
		//videoplayer = gameObject.AddComponent<VideoPlayer> ();
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		audioSource.Pause ();
		//videoplayer.source = VideoSource.Url;
		//videoplayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
		//videoPlayer.source = VideoSource.VideoClip;
		//videoPlayer.clip = videoToPlay;

		videoPlayer.url = playList [currentPlaying];

		// go to next clip
		Debug.Log("Currently playing clip " + currentPlaying);
		if (currentPlaying < playList.Length) {
			currentPlaying++;
		} else {
			currentPlaying = 0;
		}
			
		// audio related
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioSource);

		//prepare video must be called after setting up audio
		videoPlayer.Prepare ();

		while (!videoPlayer.isPrepared) {
			yield return null;
		}

		//the image when no video is playing
		image.texture = videoPlayer.texture;

		while (videoPlayer.isPlaying) {
			yield return null;
		}
	}
	void OnTriggerEnter(Collider other){

		StartCoroutine (loadVideo());

		if (!videoPlayer.isPlaying) {
			videoPlayer.Play ();
			audioSource.Play ();
		}
	}

//	void OnTriggerExit(Collider other)
//	{
//		videoPlayer.Stop ();
//	}
}