using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public GameObject towerPrefab;

    Tower tower;

	// Initialization
	void Start () {

	}
	
	// Called once per frame
	void Update () {
	
	}

    void OnMouseEnter() {
		if (tower == null) {
            GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.35f);
        }
    }

    void OnMouseExit() {
		if (tower == null) {
            GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.35f);
        }
    }

	void OnMouseDown() {
		if (tower == null) {
			// FIX POSITION TO CENTER
			tower = (Tower)((GameObject)Instantiate(towerPrefab, new Vector3(this.transform.position.x + 0.2f, this.transform.position.y - 0.2f, this.transform.position.z), Quaternion.identity)).GetComponent("Tower");
		}
	}
}
