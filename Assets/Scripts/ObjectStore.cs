using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStore : MonoBehaviour {
	public List<LanguageObject> words = new List<LanguageObject>();
	public PlayerController player;
	public TranslationObject i18n;

	// Use this for initialization

	void Start() {
		this.i18n = new TranslationObject("DE");
		this.player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	public void RegisterLanguageObject(LanguageObject word) {
		words.Add(word);
	}
}
