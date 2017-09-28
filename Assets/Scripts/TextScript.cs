using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (text != null) {
			text.text = GlobalGameState.instance.capital;
		}
	}
}
