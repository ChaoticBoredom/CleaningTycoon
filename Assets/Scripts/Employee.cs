﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour {
  public Vector2 location;
  private Vector2 initialLocation;
  private List<Residence> assignedResidences;
  private Residence currentResidence;
  private float cleanRate = 2.5f;
  private float speed = 10.0f;
  private bool employed = false;
  private bool goingHome = false;

  public bool highlighted = false;

	// Use this for initialization
	void Start () {
    initialLocation = new Vector2(transform.position.x, transform.position.y);
    location = initialLocation;
    assignedResidences = new List<Residence>();
    InvokeRepeating("payEmployee", 1, 1);
    InvokeRepeating("goToWork", 1, 1);
	}

	// Update is called once per frame
	void Update () {
    if (goingHome) {
      if (location == initialLocation) {
        goingHome = false;
      } else {
        moveToLocation(initialLocation);
      }
    }
    moveToResidence(currentResidence);
	}

  void OnMouseDown() {
    if (GlobalGameState.instance.CurrentlySelectedEmployee == this) {
      GlobalGameState.instance.CurrentlySelectedEmployee = null;
      markSelected(false);
    } else {
      if (GlobalGameState.instance.CurrentlySelectedEmployee != null) {
        GlobalGameState.instance.CurrentlySelectedEmployee.markSelected(false);
      }
      GlobalGameState.instance.CurrentlySelectedEmployee = this;
      markSelected(true);
      if (this.employed == false) {
        employ ();
      }
    }
  }

  public void markSelected(bool state) {
    highlighted = state;

    for(int i = 0; i < assignedResidences.Count; i++) {
      assignedResidences[i].highlighted = state;
    }
  }

  void moveToResidence(Residence targetResidence) {
    if (currentResidence == null || this.location == currentResidence.location) {
      return;
    }
    moveToLocation(targetResidence.location);
  }

  void moveToLocation(Vector2 newLocation) {
    float step = speed * Time.deltaTime;
    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), newLocation, step);
    location.x = transform.position.x;
    location.y = transform.position.y;
  }

  void goToWork() {
    if (assignedResidences.Count == 0) {
      return;
    }

    if (currentResidence != null) {
      if (this.location == currentResidence.location) {
        if (currentResidence.isClean) {
          currentResidence = findNextDirtyResidence(currentResidence);
        } else {
          currentResidence.cleanHouse(cleanRate);
        }
      }
    } else {
      currentResidence = findNextDirtyResidence(currentResidence);
    }
  }

  void payEmployee() {
    GlobalGameState.instance.decrementCapital(1);
  }

  public void assignResidence(Residence residence) {
    if (assignedResidences.Contains(residence)) {
      return;
    }
    assignedResidences.Add(residence);
  }

  public void unassignResidence(Residence residence) {
    assignedResidences.Remove(residence);
  }

  private Residence findNextDirtyResidence(Residence startingResidence = null) {
    int startingIndex;
    if (startingResidence == null) {
      startingIndex = 0;
    } else {
      startingIndex = assignedResidences.IndexOf(startingResidence);
    }

    for(int i = startingIndex; i < assignedResidences.Count; i++) {
      if (assignedResidences[i].isDirty()) {
        return assignedResidences[i];
      }
    }

    for(int i = 0; i < startingIndex; i++) {
      if (assignedResidences[i].isDirty()) {
        return assignedResidences[i];
      }
    }
    goingHome = true;
    return null;
  }

  private void employ() {
    this.employed = true;
    GlobalGameState.instance.decrementCapital (20);
  }
}
