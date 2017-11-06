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

	public void FadeIn() {
		canvas.alpha = 1;
	}

	public void FadeOut() {
		canvas.alpha = 0;
	}
}
