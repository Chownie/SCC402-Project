using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageObject : MonoBehaviour {
	public TranslationObject.ApplicableVerbs verbs;
	public string gender = "";
	public string word = "";
	private PlayerController player;

	void Start() {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	public void getInputs() {
		word = "";
		word += "0: " +Input.GetKey(KeyCode.JoystickButton0).ToString() + "\n";
		word += "1: " +Input.GetKey(KeyCode.JoystickButton1).ToString() + "\n";
		word += "2: " +Input.GetKey(KeyCode.JoystickButton2).ToString() + "\n";
		word += "3: " +Input.GetKey(KeyCode.JoystickButton3).ToString() + "\n";
		word += "4: " +Input.GetKey(KeyCode.JoystickButton4).ToString() + "\n";
		word += "5: " +Input.GetKey(KeyCode.JoystickButton5).ToString() + "\n";
		word += "Horizontal: " + Input.GetAxis("Horizontal") + "\n";
		word += "Vertical: " + Input.GetAxis("Vertical");
		FadeIn();
	}

	public void FadeIn() {
		player.Show(word, gender, verbs);
	}

	public void FadeOut() {
		player.Hide();
	}
}
