using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
    public string towerSelection { get; set; }
	public GUIText lifesText, wavesText, moneyText;
	public GameObject highlight; // Yellow highlight sprite for selections

    Grid grid; // The grid of the game, containing the path and tower locations
	Wave wave; // The actual wave of ennemies

	int lifes, money; // Number of times enemies can reach the end before the game is over and money available for towers

	// Creation of the game
    void Awake() {
        DontDestroyOnLoad(gameObject);
        instance = this;
		grid = (Grid)transform.Find("Grid").gameObject.GetComponent("Grid");
		wave = (Wave)transform.Find("Wave").gameObject.GetComponent("Wave");
		towerSelection = "None";
		lifes = 20;
		money = 50;
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
			highlight.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	public void LoseLife() {
		lifes--;
		lifesText.text = "LIFES: " + lifes;
	}

	public void HighlightObject(Vector3 position) {
		highlight.GetComponent<SpriteRenderer>().enabled = true;
		highlight.transform.position = position;
	}

	public Waypoint GetWaypoint(int index) {
		return grid.GetWaypoint(index);
	}
}