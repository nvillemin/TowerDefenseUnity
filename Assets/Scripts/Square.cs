using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public GameObject towerPrefab;

    Tower tower;
    bool isPath;

	// Initialization
	void Start () {

	}
	
	// Called once per frame
	void Update () {
	
	}

    public void SetPath() {
        if (!isPath) {
            this.isPath = true;
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
    }

    void OnMouseEnter() {
		if (!isPath && tower == null) {
            GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.35f);
        }
    }

    void OnMouseExit() {
		if (!isPath && tower == null) {
            GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.35f);
        }
    }

	void OnMouseDown() {
		if (!isPath && tower == null) {
			// FIX POSITION TO CENTER
			tower = (Tower)((GameObject)Instantiate(towerPrefab, new Vector3(this.transform.position.x + 0.2f, this.transform.position.y - 0.2f, this.transform.position.z), Quaternion.identity)).GetComponent("Tower");
		}
	}
}
