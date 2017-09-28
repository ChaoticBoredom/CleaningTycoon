﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour {

  private static GlobalGameState singletonInstance = null;
  private int capital;

  

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
	}
	
	// Update is called once per frame
	void Update () {

	}

  public void decrementCapital(int amount = 0) {
    capital -= amount;
  }
}
