using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour {

  private List<Residence> assignedResidences;
  private Residence currentResidence;
  private float cleanRate = 1.0f;

	// Use this for initialization
	void Start () {
    assignedResidences = new List<Residence>();
    InvokeRepeating("payEmployee", 1, 1);
    InvokeRepeating("cleanResidence", 1, 1);
	}

	// Update is called once per frame
	void Update () {
	}

  void OnMouseDown() {
    GlobalGameState.instance.CurrentlySelectedEmployee = this;
  }

  void cleanResidence() {
    if (assignedResidences.Count == 0) {
      return;
    }

    currentResidence = findNextDirtyResidence(currentResidence);

    if (currentResidence != null) {
      currentResidence.cleanHouse(cleanRate);
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
