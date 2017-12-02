using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

delegate TResult TResult();

public class TutorController : MonoBehaviour {
	public float maxHeight = 7f;
	public float minHeight = 5f;
	public float speed = 0.5f;
	public int testWordCount = 1;
	
	// Faces
	public Image Face;
	public Sprite Default;
	public Sprite Left;
	public Sprite Right;
	public Sprite Sad;
	public Sprite Angry;
	public Sprite Find;

	public Text textBox;

	private bool boost = false;
	private TResult state;

	private LanguageObject target;
	private List<LanguageObject> targets = new List<LanguageObject>();

	private int score = 0;

	private bool interacting = false;

	private ObjectStore objectStore;

	// Use this for initialization
	void Start () {
		this.objectStore = GameObject.Find("/Base_Scene").GetComponent<ObjectStore>();
		this.state = Idle;
		List<LanguageObject> tempTargets = objectStore.words;
		for(int i = 0; i < testWordCount; i++) {
			LanguageObject selection = tempTargets[Random.Range(0, tempTargets.Count)];
			tempTargets.Remove(selection);
			targets.Add(selection);
		}
	}
	
	public void SetInteracting(bool input) {
		this.interacting = input;
	}

	private TResult Confirming() {
		this.textBox.text = "Do you want to quit?\n Select me again to quit";
		if(Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.R)) {
			if(this.interacting) {
				this.Face.sprite = this.Angry;
				return Idle;
			}
			if(this.objectStore.player.word.Equals(this.objectStore.i18n.GetLocalizedString(this.target.word))) {
				this.score += 1;
				this.Face.sprite = this.Default;
				return Idle;
			} else {
				this.Face.sprite = this.Sad;
				return PickingObject;
			}
		}
		return Confirming;
	}

	private TResult Hunting() {
		if(Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.R)) {
			if(this.interacting) {
				return Confirming;
			}

			if(this.objectStore.player.word.Equals(this.objectStore.i18n.GetLocalizedString(this.target.word))) {
				this.score += 1;
				this.Face.sprite = this.Default;
				return PickingObject;
			} else {
				this.Face.sprite = this.Sad;
				return PickingObject;
			}
		}
		textBox.text = "Find: \n" + this.objectStore.i18n.GetLocalizedString(this.target.word);
		return Hunting;
	}

	private TResult PickingObject() {
		this.objectStore.player.Popup(false);
		Face.sprite = Find;
		this.targets.Remove(this.target);
		if(this.targets.Count == 0) {
			this.target = null;
			return DoneAllObjects;
		}
		this.target = this.targets[Random.Range(0, this.targets.Count)];
		return Hunting;
	}

	private TResult DoneAllObjects() {
		this.objectStore.player.Popup(true);
		this.textBox.text = "Final score: " + this.score;
		if(this.Face.sprite.Equals(this.Left)) {
			this.Face.sprite = this.Right;
		} else {
			this.Face.sprite = this.Left;
		}
		return DoneAllObjects;
	}

	private TResult Idle() {
		this.objectStore.player.Popup(true);
		if(Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.R) && this.interacting) {
			return PickingObject;
		}
		this.textBox.text = "Current score: " + this.score + "\nSelect me to try a memory game";
		return Idle;
	}

	private void FSM() {
		TResult newState = this.state();
		this.state = newState;
	}

	// Update is called once per frame
	void Update () {
		// ==========Slow up/down movement==============
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
		// =============================================

		this.FSM();
	}
}
