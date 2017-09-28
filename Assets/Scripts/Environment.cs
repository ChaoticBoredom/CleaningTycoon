using UnityEngine;

public class Environment : MonoBehaviour {
  void OnMouseDown() {
    if (GlobalGameState.instance.CurrentlySelectedEmployee != null) {
      GlobalGameState.instance.CurrentlySelectedEmployee.markSelected(false);
    }
		GlobalGameState.instance.CurrentlySelectedEmployee = null;
  }
}
