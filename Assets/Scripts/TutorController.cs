using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorController : MonoBehaviour {

	public float maxHeight = 7f;
	public float minHeight = 5f;
	public float speed = 0.5f;
	private bool boost = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!boost) {
			transform.position += -Vector3.up * speed;
			if(transform.position.y < minHeight) {
				boost = !boost;
			}
		} else {
			transform.position += Vector3.up * speed;
			if(transform.position.y > maxHeight) {
				boost = !boost;
			}
		}
	}
}
