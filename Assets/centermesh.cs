using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centermesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			child.position = child.GetComponent<Renderer>().bounds.center;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
