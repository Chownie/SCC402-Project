using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	// Update is called once per frame
	public enum ControlMethod{Smooth, Blink};
	public ControlMethod controlMethod;
	public float Speed = 1.0f;

	private bool popup = true;

	private Camera cam;
	private CanvasGroup group;

	[SerializeField]
	private Text wordText;
	[SerializeField]
	private Text genderText;
	[SerializeField]
	private Text verbsText;

	// Resources
	TranslationObject i18n;

	void SmoothControl() {
		float distance = Input.GetAxis("Vertical"); 
		if (distance > 0.3) {
			transform.position += (cam.transform.forward*Speed) * Time.deltaTime;
		}
		if (distance < -0.3) {
			transform.position -= (cam.transform.forward*Speed) * Time.deltaTime;
		}
		transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
	}

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
		i18n = new TranslationObject("DE");
		cam = GetComponentInChildren<Camera>();
		group = cam.GetComponentInChildren<CanvasGroup>();
	}

	public bool TogglePopup() {
		Debug.Log("Toggling popups");
		this.popup = !this.popup;
		return this.popup;
	}

	public void Show(string text, TranslationObject.ApplicableVerbs verbs) {
		if (!this.popup) {
			Debug.Log("No popups for you!");
			return;
		}
		wordText.text = i18n.GetLocalizedString(text);
		genderText.text = i18n.GetLocalizedGender(text);
		verbsText.text = "";
		foreach (string verb in i18n.GetVerbs(verbs)) {
			verbsText.text += verb + "\n";
		}
		verbsText.text = verbsText.text.TrimEnd("\n".ToCharArray());
		group.alpha = 1;
	}

	public void Hide() {
		group.alpha = 0;
	}

	void Update () {
		if(controlMethod == ControlMethod.Smooth) {
			SmoothControl();
		}
		if(controlMethod == ControlMethod.Blink) {
			BlinkControl();
		}
	}
}
