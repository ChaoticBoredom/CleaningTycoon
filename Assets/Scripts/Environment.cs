using UnityEngine;

public class Environment : MonoBehaviour {
  void OnMouseDown() {
    GlobalGameState.instance.CurrentlySelectedEmployee.markSelected(false);
		GlobalGameState.instance.CurrentlySelectedEmployee = null;
  }
}
