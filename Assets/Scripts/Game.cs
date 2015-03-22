using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
    public string towerSelection { get; set; }
	public GUIText lifesText, wavesText;

    Grid grid; // The grid of the game, containing the path and tower locations
	Wave wave; // The actual wave of ennemies

	int lifes; // Number of times enemies can reach the end before the game is over

	// Creation of the game
    void Awake() {
        DontDestroyOnLoad(gameObject);
        instance = this;
		grid = (Grid)transform.Find("Grid").gameObject.GetComponent("Grid");
		wave = (Wave)transform.Find("Wave").gameObject.GetComponent("Wave");
		towerSelection = "None";
		lifes = 20;
    }

	// Destruction of the game
    void OnDestroy() {
        instance = null;
    }

	// Called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			wave.Next();
			wavesText.text = "WAVE " + wave.number;
		}
		else if (Input.GetKeyDown("escape")) {
			towerSelection = "None";
		}
	}

	public void LoseLife() {
		lifes--;
		lifesText.text = "LIFES: " + lifes;
	}

	public Waypoint GetWaypoint(int index) {
		return grid.GetWaypoint(index);
	}
}