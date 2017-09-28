using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour {

  private static GlobalGameState singletonInstance = null;
  private int capital;
  private float appearRate;

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
    appearRate = 300.0f;
	}
	
	// Update is called once per frame
	void Update () {
    appearRate -= Time.deltaTime;
    if(appearRate < 0){
      GameObject go = (GameObject)Instantiate(Resources.Load("Residence")); ;
      appearRate = 300.0f;   
    }
	}

  public void decrementCapital(int amount = 0) {
    capital -= amount;
  }
}
