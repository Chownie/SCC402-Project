using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class LanguageObject : MonoBehaviour {
	public TranslationObject.ApplicableVerbs verbs;
	public string word = "";
	private ObjectStore objectStore;

	void Start() {
		this.objectStore = GameObject.Find("/Base_Scene").GetComponent<ObjectStore>();
		this.objectStore.RegisterLanguageObject(this);
	}

	public void getInputs() {
		word = "";
		word += "0: " +Input.GetKey(KeyCode.JoystickButton0).ToString() + "\n";
		word += "1: " +Input.GetKey(KeyCode.JoystickButton1).ToString() + "\n";
		word += "2: " +Input.GetKey(KeyCode.JoystickButton2).ToString() + "\n";
		word += "3: " +Input.GetKey(KeyCode.JoystickButton3).ToString() + "\n";
		word += "4: " +Input.GetKey(KeyCode.JoystickButton4).ToString() + "\n";
		word += "5: " +Input.GetKey(KeyCode.JoystickButton5).ToString() + "\n";
		FadeIn();
	}

	public void FadeIn() {
		objectStore.player.Show(word, verbs);
	}

	public void FadeOut() {
		objectStore.player.Hide();
	}
}
