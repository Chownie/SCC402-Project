using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epilepsy : MonoBehaviour {
	Renderer rend;
	// Use this for initialization
	Color left = Color.red;
	Color right = Color.green;
void Start() {
        rend = GetComponent<Renderer>();
		InvokeRepeating("FlickerColor", 2.0f, 0.2f);
    }
	
	// Update is called once per frame
	void FlickerColor () {
		if(left == Color.red) {
			left = Color.yellow;
		} else {
			left = Color.red;
		}

		if(right == Color.green) {
			right = Color.blue;
		} else {
			right = Color.green;
		}

		rend.material.SetColor("_Left", left);
		rend.material.SetColor("_Right", right);
	}
}
