using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageObject : MonoBehaviour {
	public string word = "";
	public Text text;
	public CanvasGroup canvas;
	GameObject cam;

	void Start() {
		text.text = word;
		cam = GameObject.Find("Main Camera");
	}

	void Update () {
		canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - cam.transform.position);
	}

	public void getInputs() {
		text.text = "";
		text.text += "0: " +Input.GetKey(KeyCode.JoystickButton0).ToString() + "\n";
		text.text += "1: " +Input.GetKey(KeyCode.JoystickButton1).ToString() + "\n";
		text.text += "2: " +Input.GetKey(KeyCode.JoystickButton2).ToString() + "\n";
		text.text += "3: " +Input.GetKey(KeyCode.JoystickButton3).ToString() + "\n";
		text.text += "4: " +Input.GetKey(KeyCode.JoystickButton4).ToString() + "\n";
		text.text += "5: " +Input.GetKey(KeyCode.JoystickButton5).ToString() + "\n";
		text.text += "Horizontal: " + Input.GetAxis("Horizontal") + "\n";
		text.text += "Vertical: " + Input.GetAxis("Vertical");
		FadeIn();
	}

	public void FadeIn() {
		canvas.alpha = 1;
	}

	public void FadeOut() {
		canvas.alpha = 0;
	}
}
