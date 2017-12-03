using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class emission : MonoBehaviour {

	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		InvokeRepeating("UpdateGI", 0, 0.1F);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void UpdateGI (){
		RendererExtensions.UpdateGIMaterials(renderer);
	}
}
