using UnityEngine;
using System.Collections;

public class TowerSelection : MonoBehaviour {

	// Selection of the tower to place
	void OnMouseDown() {
		Game.Instance.towerSelection = name;
		Game.Instance.HighlightObject(transform.position);
	}
}
