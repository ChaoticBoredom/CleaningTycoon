using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GlobalGameState.instance.decrementCapital(1);
	}
}
