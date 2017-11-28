using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorController : MonoBehaviour {

	public float maxHeight = 7f;
	public float minHeight = 5f;
	public float speed = 0.5f;
	
	// Faces
	public Image Face;
	public Sprite Default;
	public Sprite Left;
	public Sprite Right;
	public Sprite Sad;
	public Sprite Angry;
	public Sprite Find;

	private bool boost = false;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("/Base_Scene/Player").GetComponent<PlayerController>();
	}
	
	void FaceMode() {

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
		if(Input.GetKeyDown(KeyCode.JoystickButton0)) {
			if(player.TogglePopup()) {
				Face.sprite = Find;
			} else {
				Face.sprite = Default;
			}
		}
	}
}
