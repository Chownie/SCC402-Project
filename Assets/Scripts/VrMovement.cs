using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrMovement : MonoBehaviour {
	// Update is called once per frame
	public enum ControlMethod{Smooth, Blink};

	public ControlMethod controlMethod;

	public float Speed = 1.0f;
	private Transform facing;

	public Image blinkImage;

	private Camera cam;
	/*void SmoothControl() {
		float distance = Input.GetAxis("Vertical"); 
		if (distance > 0.3) {
			transform.position += (facing.forward*Speed) * Time.deltaTime;
		}
		if (distance < -0.3) {
			transform.position -= (facing.forward*Speed) * Time.deltaTime;
		}
		transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
	}*/

	void BlinkControl() {
		/*if(Input.GetKeyDown(KeyCode.JoystickButton3)) {
			Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				blinkImage.CrossFadeAlpha(1.0f, 0.25f, false);
				transform.position = hit.point;
				blinkImage.CrossFadeAlpha(0.0f, 0.25f, false);
			}
		}*/
	}

	void Start() {
		cam = GetComponentInChildren<Camera>();
		facing = cam.transform;
	}

	void Update () {
		float distance = Input.GetAxis("Vertical"); 
		if (distance > 0.3) {
			transform.position += (facing.forward*Speed) * Time.deltaTime;
		}
		if (distance < -0.3) {
			transform.position -= (facing.forward*Speed) * Time.deltaTime;
		}
		transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
		
		if(controlMethod == ControlMethod.Smooth) {
			
		}
		if(controlMethod == ControlMethod.Blink) {
			BlinkControl();
		}
	}
}
