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

    if (currentResidence == null) {
      foreach(Residence residence in assignedResidences) {
        if (residence.is_dirty()) {
          currentResidence = residence;
        }
      }
    }

    if (currentResidence.is_clean()) {
      int nextIndex = assignedResidences.IndexOf(currentResidence) + 1;
      if (nextIndex > assignedResidences.Count) {
        nextIndex = 0;
      }
      currentResidence = assignedResidences[nextIndex];
    }

    currentResidence.cleanSomething(1.0f);
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
}
