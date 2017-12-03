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

public class SingleScreenControl : MonoBehaviour {
//	public RawImage image;
	public VideoClip videoToPlay;
	public VideoPlayer videoPlayer;
//	public VideoSource videoSource;
//	public string[] playList = new string[22];
	public string[] playList;
	public AudioSource audioSource;
	public int currentPlaying = 0;
//	GameObject[] allTriggers;

	public Vector3 center;
	public float r;
	public Transform eye;
	public GameObject floatScreen;
	public GameObject newScreen;

	private bool isPlayerMoved = false;
	private Vector3 position_prev;
	private Vector3 position_curr;
	private float nextFire = 0.5f;

	void Start () 
	{
//		Application.runInBackground = true;

		// load all videos into playlist
		for (int i = 0; i < playList.Length; i++) {
			playList [i] = "file://" + Application.dataPath + "/Resources/Videos/" + i + ".mp4";
		}

//		allTriggers = GameObject.FindGameObjectsWithTag ("videotriggers");

			//start a coroutine task
			//		StartCoroutine (loadVideo());
		position_prev = GameObject.Find ("FPSController").transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextFire) {

//		if (Input.GetKeyUp (KeyCode.Q)&&(videoPlayer==null||!videoPlayer.isPlaying)) 
//		{
//			spawnScreen ();
//		}

		position_curr = GameObject.Find("FPSController").transform.position;
		float displacement = Mathf.Sqrt (Mathf.Pow (position_curr.x - position_prev.x, 2) + Mathf.Pow (position_curr.z - position_prev.z, 2));

//		print ("Current time " + Time.time + ", The displacement = " + displacement);
		if (displacement > 1) {
			isPlayerMoved = true;
		} else {
			isPlayerMoved = false;
		}

			nextFire = Time.time + 1;
			position_prev = position_curr;
				
		if (isPlayerMoved&&(videoPlayer==null||!videoPlayer.isPlaying)) 
		{
			spawnScreen ();
		}

		}
		// wait for video to finish
		// position chagne 1 , then spawnScreen


		//		allTriggers = GameObject.FindWithTag ("videotriggers").GetComponent<BoxCollider> ();
		//		Debug.Log (allTriggers);

//		if (videoPlayer.isPlaying) {
//			foreach (GameObject pad in allTriggers) {
//				pad.SetActive (false);
//			} 

			//diable the triggers until video finish;
			//			allTriggers.enabled = (false);
			//			Debug.Log("Disable: " + gameObject.name);
			//			gameObject.GetComponent(videoPlayer).SetActive (false);
			//			bool triggerStatus = gameObject.GetComponentInChildren(typeof(VideoClip)) as bool
//		}
	}

//	IEnumerator loadVideo()
//	{
//		videoPlayer.playOnAwake = false;
//		audioSource.playOnAwake = false;
//		audioSource.Pause ();
//		//videoplayer.source = VideoSource.Url;
//		//videoplayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
//		//videoPlayer.source = VideoSource.VideoClip;
//		//videoPlayer.clip = videoToPlay;
//
//
//		// go to next clip
//		Debug.Log("Currently playing clip " + currentPlaying);
//		if (currentPlaying >= playList.Length) {
//			currentPlaying = 0;
//		} else {
//			currentPlaying++;
//		}
//
//		videoPlayer.url = playList [currentPlaying];
//
//		// audio related
//		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
//		videoPlayer.EnableAudioTrack (0, true);
//		videoPlayer.SetTargetAudioSource (0, audioSource);
//
//		//prepare video must be called after setting up audio
//		videoPlayer.Prepare ();
//
//		//Wait until video is prepared
////		WaitForSeconds waitTime = new WaitForSeconds(1);
////		while (!videoPlayer.isPrepared)
////		{
////			Debug.Log("Preparing Video");
////			//Prepare/Wait for 5 sceonds only
////			yield return waitTime;
////			//Break out of the while loop after 5 seconds wait
////			break;
////		}
//
//		//the image when no video is playing
////		image.texture = videoPlayer.texture;
//
//		while (videoPlayer.isPlaying) {
//			yield return null;
//		}
//
//		if (!videoPlayer.isPlaying) {
//			videoPlayer.Play ();
//			audioSource.Play ();
//		}
//	}

//	void OnTriggerEnter(Collider other){
//
//		StartCoroutine (loadVideo());
//
//		if (!videoPlayer.isPlaying) {
//			videoPlayer.Play ();
//			audioSource.Play ();
//		}
//	}



	public void spawnScreen()
	{
		Vector3 pos = center + new Vector3(1.2f * Random.Range(-r,r),Random.Range(1,r-2),1.2f * Random.Range(-r,r));
		Vector3 relativePos = eye.position - pos;
		newScreen = Instantiate (floatScreen, pos, Quaternion.LookRotation (relativePos)) as GameObject;
		print("cureent LookRotation is " + relativePos + ", screen pos is " + pos + "eye pos is" + eye.position);

//		currentScreen.AddComponent<VideoPlayer> ();
		videoPlayer = newScreen.GetComponent<VideoPlayer>();
		audioSource = newScreen.GetComponent<AudioSource> ();

//		StartCoroutine (loadVideo());
		loadVideo();


	}

	void loadVideo()
	{
		// go to next clip
		Debug.Log("Currently playing clip " + currentPlaying);
		if (currentPlaying >= playList.Length) {
			currentPlaying = 0;
		} else {
			currentPlaying++;
		}

		videoPlayer.url = playList [currentPlaying];

		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		//audioSource.Pause ();

		//videoplayer.source = VideoSource.Url;
		//videoplayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
		//videoPlayer.source = VideoSource.VideoClip;
		//videoPlayer.clip = videoToPlay;

		//Set Audio Output to AudioSource
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack (1, true);
		videoPlayer.SetTargetAudioSource (1, audioSource);

		//prepare video must be called after setting up audio
		videoPlayer.Prepare ();

	}


	//	void OnTriggerExit(Collider other)
	//	{
	//		videoPlayer.Stop ();
	//	}
}