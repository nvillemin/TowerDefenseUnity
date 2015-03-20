using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
    
    Grid grid; // The grid of the game, containing the path and tower locations
	Wave wave; // The actual wave of ennemies

	// Creation of the game
    void Awake() {
        DontDestroyOnLoad(gameObject);
        instance = this;
		grid = (Grid)transform.Find("Grid").gameObject.GetComponent("Grid");
		wave = (Wave)transform.Find("Wave").gameObject.GetComponent("Wave");
    }

	// Destruction of the game
    void OnDestroy() {
        instance = null;
    }

	// Called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			wave.Next();
		}
	}

	public void LoseLife() {
		// Add stuff to lower life count
	}

	public Waypoint GetWaypoint(int index) {
		return grid.GetWaypoint(index);
	}
}