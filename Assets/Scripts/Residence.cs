using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location;
  public float startingDirt = 10.0f;
  public float dirtRate = 2.0f;
	public float currentDirt;

	public bool isClean;
	public int cleaningWorth;

	public bool highlighted = false;

	private float DIRTY_THRESHOLD = 15.0f;
  private Animator animator;

  // Use this for initialization
	void Start () {
		location = new Vector2(transform.position.x, transform.position.y);
    animator = GetComponent<Animator>();
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
			highlighted = true;
    }
  }

  private void getDirty() {
    if (isDirty()) {
      return;
    }

    currentDirt += dirtRate;
    if (currentDirt >= DIRTY_THRESHOLD) {
      dirtied();
    }
  }

  public void cleanHouse(float cleanRate = 1.0f) {
    if (isClean) {
      return;
    }
    animator.SetBool("Cleaning", true);

    currentDirt -= cleanRate;
    if (currentDirt <= 0) {
      cleaned();
    }
  }

	public void cleaned () {
		isClean = true;
		GlobalGameState.instance.incrementCapital(cleaningWorth);
    animator.SetBool("Clean", true);
    animator.SetBool("Cleaning", false);
	}

	private void dirtied () {
    animator.SetBool("Clean", false);
		isClean = false;
	}

	public bool isDirty(){
		return !isClean;
	}
}
