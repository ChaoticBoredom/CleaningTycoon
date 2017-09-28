using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location = new Vector2(0,0);
	public float dirtRate = 100.0f;

	public bool isClean;
	public int cleaningWorth;

  private ParticleSystem particleSystem;
	// Use this for initialization
	void Start () {
    particleSystem = gameObject.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
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

  void OnMouseDown() {
    Employee currentEmployee = GlobalGameState.instance.CurrentlySelectedEmployee;
    if (currentEmployee == null) {
      return;
    } else {
      currentEmployee.assignResidence(this);
    }
  }

	public void cleaned () {
		isClean = true;
    particleSystem.Stop();
		GlobalGameState.instance.incrementCapital(cleaningWorth);
	}

	private void getsDirty () {
    particleSystem.Play();
		isClean = false;
	}

	public bool isDirty(){
		return !isClean;
	}
}
