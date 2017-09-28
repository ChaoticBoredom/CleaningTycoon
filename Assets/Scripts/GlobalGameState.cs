using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour {

  private static GlobalGameState singletonInstance = null;
  private int capital;
  private Employee currentlySelectedEmployee;
  public float appearRate;

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
    appearRate = 1.0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
    if(appearRate > 0){
      appearRate -= Time.deltaTime;
    }
    else{
      Vector2 screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width), Random.Range(0,Screen.height)));
      GameObject newResidence = Instantiate(residence);
      //Can add code here to customize new residences when they get created
      //Resets the house spawn timer
      //appearRate = 2.0f;
      newResidence.transform.position = screenPosition;
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
