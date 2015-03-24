using UnityEngine;
using System.Collections;

public class TowerSelection : MonoBehaviour {

	// Selection of the tower to place
	void OnMouseDown() {
		switch(name) {
		case "Selection Tower Red":
			Game.Instance.towerSelection = "Red";
			break;
		case "Selection Tower Blue":
			Game.Instance.towerSelection = "Blue";
			break;
		}
		Game.Instance.HighlightObject(transform.position);
	}
}
