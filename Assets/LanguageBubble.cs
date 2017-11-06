using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageBubble : MonoBehaviour {
	GameObject cam;
	// Use this for initialization
	

	void Start () {
		cam = GameObject.Find("Camera");
		Debug.Log(cam);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
	}
}
