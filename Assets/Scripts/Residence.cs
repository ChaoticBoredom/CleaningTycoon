using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location = new Vector2(0,0);
	public float appearRate = 1.0f;
	public float dirtRate = 100.0f;

	public int assignedWorkers;
	public bool isClean;

	// Use this for initialization
	void Start () {
		isClean = false;
		assignedWorkers = 0;
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

  void OnMouseDown() {
    GlobalGameState.instance.CurrentlySelectedEmployee.assignResidence(this);
  }

	void Cleaned () {
		isClean = true;
	}
	
	private void getsDirty () {
		isClean = false;
	}

  public bool is_dirty() {
    return true;
  }

  public bool is_clean() {
    return false;
  }

  public void cleanSomething(float cleanRate = 1.0f) {

  }

}
