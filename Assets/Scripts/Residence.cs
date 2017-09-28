using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location = new Vector2(0,0);
  public float startingDirt = 10.0f;
  public float dirtRate = 1.0f;
	public float currentDirt; 

	public bool isClean;
	public int cleaningWorth;

  private ParticleSystem particleSystem;
	// Use this for initialization
	void Start () {
    particleSystem = gameObject.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
		cleaningWorth = 100;
    currentDirt = startingDirt;
    InvokeRepeating("getDirty", 1, 1);
	}

	// Update is called once per frame
	void Update () {
	}

  void OnMouseDown() {
    Employee currentEmployee = GlobalGameState.instance.CurrentlySelectedEmployee;
    if (currentEmployee == null) {
      return;
    } else {
      currentEmployee.assignResidence(this);
    }
  }

  private void getDirty() {
    if (isDirty()) {
      return;
    }

    currentDirt += dirtRate;
    if (currentDirt >= 20.0f) {
      dirtied();
    }
  }

  public void cleanHouse(float cleanRate = 1.0f) {
    if (isClean) {
      return;
    }

    currentDirt -= cleanRate;
    if (currentDirt <= 0) {
      cleaned();
    }
  }

	public void cleaned () {
		isClean = true;
    particleSystem.Stop();
		GlobalGameState.instance.incrementCapital(cleaningWorth);
	}

	private void dirtied () {
    particleSystem.Play();
		isClean = false;
	}

	public bool isDirty(){
		return !isClean;
	}
}
