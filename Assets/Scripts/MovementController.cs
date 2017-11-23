using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public int speed = 1;
	public Vector3 velocity = new Vector3 (0, 0, 10);
	public Vector3 rotateVelocity = new Vector3 (100, 100, 0);

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

//		transform.Translate (Vector3.forward * speed * Time.deltaTime); // (0,0,1) * speed --> (0,0,10)
		transform.position += velocity * speed * Time.deltaTime;

		//rotate
		transform.Rotate (rotateVelocity * speed * 100 * Time.deltaTime);
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