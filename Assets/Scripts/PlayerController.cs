using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	// Update is called once per frame
	public enum ControlMethod{Smooth, Blink};
	public ControlMethod controlMethod;
	public float Speed = 1.0f;
	public float StaticHeight = 6.0f;

	private bool popup = true;

	private Camera cam;
	private CanvasGroup group;
	private TutorController tutor;

	[SerializeField]
	private GvrReticlePointer pointer;
	[SerializeField]
	private Text wordText;
	[SerializeField]
	private Text genderText;
	[SerializeField]
	private Text verbsText;

	[SerializeField]
	private Text Score;
	[SerializeField]
	private Text Target;

	public string word;

	private string filePath;
	private string RecordedMovementData = "";

	// Resources
	private ObjectStore objectStore;

	void SmoothControl() {
		float distance = Input.GetAxis("Vertical"); 
		if (distance > 0.3) {
			transform.position += (cam.transform.forward*Speed) * Time.deltaTime;
			RecordedMovementData += transform.position.ToString() + "\n";
		}
		if (distance < -0.3) {
			transform.position -= (cam.transform.forward*Speed) * Time.deltaTime;
			RecordedMovementData += transform.position.ToString() + "\n";
		}
		transform.position = new Vector3(transform.position.x, StaticHeight, transform.position.z);
	}

	void OnApplicationQuit() {
		Debug.Log(RecordedMovementData);
		File.WriteAllText(filePath, RecordedMovementData);
	}

	void BlinkControl() {
		if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.F)) {
			RaycastResult res = pointer.CurrentRaycastResult;
			if(!res.isValid) {
				return;
			}
			if(res.gameObject.tag == "floor") {
				transform.position = new Vector3(res.worldPosition.x, StaticHeight, res.worldPosition.z);
				RecordedMovementData += transform.position.ToString() + "\n";
			}
		}
	}

	void Start() {
		Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		filePath = Application.persistentDataPath + "/MOVE_" + unixTimestamp.ToString() + ".csv";
		this.objectStore = GameObject.Find("/Base_Scene").GetComponent<ObjectStore>();
		cam = GetComponentInChildren<Camera>();
		group = cam.GetComponentInChildren<CanvasGroup>();
		tutor = GameObject.Find("Tutor").GetComponent<TutorController>();
	}

	public bool Popup(bool popup) {
		this.popup = popup;
		return this.popup;
	}

	public void Test() {
		Debug.Log("TEST");
	}

	public void Show(string text, TranslationObject.ApplicableVerbs verbs) {
		wordText.text = this.objectStore.i18n.GetLocalizedString(text);
		this.word = this.objectStore.i18n.GetLocalizedString(text);
		genderText.text = this.objectStore.i18n.GetLocalizedGender(text);
		verbsText.text = "";
		foreach (string verb in this.objectStore.i18n.GetVerbs(verbs)) {
			verbsText.text += verb + "\n";
		}
		verbsText.text = verbsText.text.TrimEnd("\n".ToCharArray());
		if (!this.popup) {
			return;
		}
		group.alpha = 1;
	}

	public void Hide() {
		group.alpha = 0;
		wordText.text = "";
		genderText.text = "";
		verbsText.text = "";
		word = "";
	}

	void Update () {
		if(controlMethod == ControlMethod.Smooth) {
			SmoothControl();
		}
		if(controlMethod == ControlMethod.Blink) {
			BlinkControl();
		}
		if(tutor.target != null) {
			Target.text = this.objectStore.i18n.GetLocalizedString(tutor.target.word);
		} else {
			Target.text = "None";
		}
		Score.text = tutor.score.ToString();
	}
}
