using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour {
  public Vector2 location;
  private List<Residence> assignedResidences;
  private Residence currentResidence;
  private float cleanRate = 2.5f;
  private float speed = 10.0f;

	// Use this for initialization
	void Start () {
    location = new Vector2(transform.position.x, transform.position.y);
    assignedResidences = new List<Residence>();
    InvokeRepeating("payEmployee", 1, 1);
    InvokeRepeating("cleanResidence", 1, 1);
	}

	// Update is called once per frame
	void Update () {
    moveToResidence(currentResidence);
	}

  void OnMouseDown() {
    GlobalGameState.instance.CurrentlySelectedEmployee = this;
  }

  void moveToResidence(Residence targetResidence) {
    if (currentResidence == null || this.location == currentResidence.location) {
      return;
    }
    float step = speed * Time.deltaTime;
    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetResidence.location, step);
    location.x = transform.position.x;
    location.y = transform.position.y;
  }

  void cleanResidence() {
    if (assignedResidences.Count == 0) {
      return;
    }

    if (currentResidence != null) {
      if (this.location == currentResidence.location) {
        if (currentResidence.isClean) {
          currentResidence = findNextDirtyResidence(currentResidence);
        }
        currentResidence.cleanHouse(cleanRate);
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

    return null;
  }
}
