using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidenceSpawner : MonoBehaviour {
	public float appearRate;

	public GameObject residence;

	// Use this for initialization
	void Start () {
		appearRate = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		// Update is called once per frame
	void FixedUpdate () {
    if(appearRate > 0){
      appearRate -= Time.deltaTime;
    }
    else{
      //Vector2 screenPosition = Vector2.zero;
      GameObject newResidence = Instantiate(residence);
      //Can add code here to customize new residences when they get created
      //Resets the house spawn timer
      appearRate = 2.0f;   
      newResidence.transform.position = createResidenceLocation();
	  if(checkColl(newResidence)){
		  newResidence.transform.position = createResidenceLocation();
		}
	  
	

    }

	}
	private Vector2 createResidenceLocation(){
    Vector2 screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width), Random.Range(0,Screen.height)));
    if(screenPosition.y < Screen.height - 4){
		screenPosition.y += 2;
	}
    return screenPosition;
  }

  private bool checkColl(GameObject newResidence){
	  object[] obj = GameObject.FindGameObjectsWithTag("Residence");
      foreach (object o in obj)  
      {
        GameObject g = (GameObject) o;
        if (newResidence.GetComponent<Renderer>().bounds.Intersects(g.GetComponent<Renderer>().bounds)) {
			return true;

        }
      }
	  return false;
  }
}
