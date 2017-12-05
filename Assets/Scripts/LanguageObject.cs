using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class LanguageObject : MonoBehaviour {
	public TranslationObject.ApplicableVerbs verbs;
	public string word = "";
	private ObjectStore objectStore;

	private Renderer parentRend;
	private Material parentMat;
	private Color parentColor;

	public Material hyperColorMat;

	public bool hypercolorHighlight = false;

	void Start() {
		this.objectStore = GameObject.Find("/Base_Scene").GetComponent<ObjectStore>();
		this.objectStore.RegisterLanguageObject(this);
		parentRend = transform.parent.GetComponent<Renderer>();
		parentMat = parentRend.material;
		parentColor = parentMat.color;
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
		if (hypercolorHighlight) {
			parentRend.material = hyperColorMat;
			parentRend.receiveShadows = false;
		} else {
			parentMat.color = Color.blue;
		}

	}

	public void FadeOut() {
		objectStore.player.Hide();
		if (hypercolorHighlight) {
			parentRend.material = parentMat;
			parentRend.receiveShadows = true;
		} else {
			parentMat.color = parentColor;
		}
	}
}
