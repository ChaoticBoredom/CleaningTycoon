using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location = new Vector2(0,0);
	public int appearRate = 1;
	public int dirtRate = 1;

	public int assignedWorkers;
	public bool isClean;

	// Use this for initialization
	void Start () {
		isClean = false;
		assignedWorkers = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Cleaned () {
		isClean = true;
	}
	
	private void getsDirty () {
		isClean = false;
	}

}
