using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//create a public variable for the player transform
	//give a value from inspector
	public Transform playerTransform;

	void Awake()
	{
		//always called before Start
		//only when game object is enabled

	}

	void Start()
	{
		//called before any frame are executed
		//use for varible loading
	}

	void Update() {

		//most game code
		//called per frame
		//frequent use of Time.deltaTime

		transform.LookAt (playerTransform);
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

}
