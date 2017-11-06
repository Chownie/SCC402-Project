using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToward : MonoBehaviour {
	GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
		Debug.Log(cam);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(-cam.transform.position);
	}
}
