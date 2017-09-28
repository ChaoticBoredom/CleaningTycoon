using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour {

  private static GlobalGameState singletonInstance = null;
  private int capital;
  private Employee currentlySelectedEmployee;
  private float appearRate;

  public GameObject residence;


  

  public static GlobalGameState instance {
    get {
      if (singletonInstance == null) {
        singletonInstance = FindObjectOfType(typeof (GlobalGameState)) as GlobalGameState;
      }

      if (singletonInstance == null) {
        GameObject obj = new GameObject("GlobalGameState");
        singletonInstance = obj.AddComponent(typeof (GlobalGameState)) as GlobalGameState;
      }

      return singletonInstance;
    }
  }

  void OnApplicationQuit() {
    singletonInstance = null;
  }

	// Use this for initialization
	void Start () {
    capital = 500;
    appearRate = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
    appearRate -= Time.deltaTime;
    Debug.Log(appearRate);
    if(appearRate < 0){
      GameObject newResidence = Instantiate(residence);
      //Can add code here to customize new residences when they get created
      appearRate = 300.0f;   
    }
	}

  public void decrementCapital(int amount = 0) {
    capital -= amount;
  }

  public void incrementCapital(int amount = 0) {
    capital += amount;
  }

  public Employee CurrentlySelectedEmployee {
    get { return currentlySelectedEmployee; }
    set { currentlySelectedEmployee = value; }
  }
}
