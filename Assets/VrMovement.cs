using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {
	// Update is called once per frame
	public float Speed = 1.0f;
	void Start() {
		Cursor.lockState = CursorLockMode.Locked;

	}

	void Update () {
		float distance = Input.GetAxis("Vertical");
		if (distance > 0) {
			transform.position += (transform.forward*Speed) * Time.deltaTime;
		}
		if (distance < 0) {
			transform.position -= (transform.forward*Speed) * Time.deltaTime;
		}
		
	}
}
