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
	//public VideoSource videoSource;
	public string[] playList = new string[6];
	public AudioSource audioSource;
	public int currentPlaying = 0;
//	GameObject[] allTriggers;

	public Vector3 center;
	public float r;
	public Transform eye;
	public GameObject floatScreen;
	private VideoPlayer currentScreen;
	private GameObject newScreen;

	private bool isPlayerMoved = false;
	private Vector3 position_prev;
	private Vector3 position_curr;

	private float nextFire=0.5f;

	void Start () 
	{
		Application.runInBackground = true;

		// load all videos into playlist
		for (int i = 0; i < playList.Length; i++) 
		{
			playList [i] = "file://" + Application.dataPath + "/Resources/Videos/" + i + ".mp4";
		}

//		allTriggers = GameObject.FindGameObjectsWithTag ("videotriggers");

		//start a coroutine task
		//		StartCoroutine (loadVideo());
		position_prev = GameObject.Find("FPSController").transform.position;
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

		print ("Current time " + Time.time + ", The displacement = " + displacement);
		if (displacement > 2) {
			isPlayerMoved = true;
		} else {
			isPlayerMoved = false;
		}


			nextFire = Time.time + 2;
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
//		while (!videoPlayer.isPrepared) {
//			yield return null;
//		}
//
//		//the image when no video is playing
////		image.texture = videoPlayer.texture;
//
//		while (videoPlayer.isPlaying) {
//			yield return null;
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

	void loadVideo()
	{
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		audioSource.Pause ();
		//videoplayer.source = VideoSource.Url;
		//videoplayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
		//videoPlayer.source = VideoSource.VideoClip;
		//videoPlayer.clip = videoToPlay;

		videoPlayer.url = playList [currentPlaying];

		// audio related
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioSource);

		//prepare video must be called after setting up audio
		videoPlayer.Prepare ();

	}

	public void spawnScreen()
	{
		Vector3 pos = center + new Vector3(Random.Range(-r,r),Random.Range(1,r-2),Random.Range(-r,r));
		Vector3 relativePos = -(pos - eye.position);


		newScreen = Instantiate (floatScreen, pos, Quaternion.LookRotation (relativePos)) as GameObject;

//		currentScreen.AddComponent<VideoPlayer> ();
//		StartCoroutine (loadVideo());
		currentScreen = newScreen.GetComponent<VideoPlayer>();
		videoPlayer = currentScreen;
		audioSource = newScreen.GetComponent<AudioSource> ();

		loadVideo();

		if (!videoPlayer.isPlaying) {
			videoPlayer.Play ();
			audioSource.Play ();
		}

		// go to next clip
		Debug.Log("Currently playing clip " + currentPlaying);
		if (currentPlaying < playList.Length) {
			currentPlaying++;
		} else {
			currentPlaying = 0;
		}
	}


	//	void OnTriggerExit(Collider other)
	//	{
	//		videoPlayer.Stop ();
	//	}
}