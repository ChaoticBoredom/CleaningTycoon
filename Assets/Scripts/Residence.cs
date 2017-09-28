using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location = new Vector2(0,0);
	public float dirtRate = 100.0f;

	public bool isClean;
	public int cleaningWorth;
	// Use this for initialization
	void Start () {
		isClean = false;
		cleaningWorth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(isClean){
			dirtRate -= Time.deltaTime;
			if(dirtRate < 0){
				getsDirty();
			}
		}
	}

	public void cleaned () {
		isClean = true;
		GlobalGameState.instance.incrementCapital(cleaningWorth);
	}
	
	private void getsDirty () {
		isClean = false;
	}

	public bool dirty(){
		return !isClean;
	}

}
