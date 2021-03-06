﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : MonoBehaviour {
	public Vector2 location;
  public float startingDirt = 10.0f;
  public float dirtRate = 2.0f;
	public float currentDirt;

	public bool isClean;
	public int cleaningWorth = 30;

	public bool highlighted = false;

	private float DIRTY_THRESHOLD = 15.0f;
  private Animator animator;

	public Renderer rend;

  // Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		location = new Vector2(transform.position.x, transform.position.y);
    animator = GetComponent<Animator>();
    currentDirt = startingDirt;
    InvokeRepeating("getDirty", 1, 1);
	}

	// Update is called once per frame
	void Update () {
		if (highlighted) {
			rend.material.color = Color.cyan;
		} else {
			rend.material.color = Color.white;
		}
	}

  void OnMouseDown() {
    Employee currentEmployee = GlobalGameState.instance.CurrentlySelectedEmployee;
    if (currentEmployee == null) {
      return;
    } else {
			if (!highlighted) {
	      currentEmployee.assignResidence(this);
				highlighted = true;
			} else {
				currentEmployee.unassignResidence(this);
				highlighted = false;
			}
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
