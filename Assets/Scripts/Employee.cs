using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour {

  private List<Residence> assignedResidences;
  private Residence currentResidence;

	// Use this for initialization
	void Start () {
    assignedResidences = new List<Residence>();
    InvokeRepeating("payEmployee", 1, 1);
    InvokeRepeating("cleanResidence", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}

  void cleanResidence() {
    if (assignedResidences.Count == 0) {
      return;
    }

    if (currentResidence == null) {
      foreach(Residence residence in assignedResidences) {
        if (residence.dirty()) {
          currentResidence = residence;
        }
      }
    }

    if (currentResidence.clean()) {
      int nextIndex = assignedResidences.IndexOf(currentResidence) + 1;
      if (nextIndex > assignedResidences.Count) {
        nextIndex = 0;
      }
      currentResidence = assignedResidences[nextIndex];
    }

    currentResidence.cleanSomething();
  }

  void payEmployee() {
    GlobalGameState.instance.decrementCapital(1);
  }

  void assignResidence(Residence residence) {
    assignedResidences.Add(residence);
  }

  void unassignResidence(Residence residence) {
    assignedResidences.Remove(residence);
  }
}
