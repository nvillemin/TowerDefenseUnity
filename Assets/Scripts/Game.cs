using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
	public GameObject currentTowerPrefab { get; set; }
	public GUIText lifesText, wavesText, moneyText, infoTitleText, infoText;
	public GameObject highlight; // Yellow highlight sprite for selections
	public int money; // Money available for towers
	public GameObject healthBarPrefab;

    private Grid grid; // The grid of the game, containing the path and tower locations
	private Wave wave; // The actual wave of ennemies
	private int lifes; // Number of times enemies can reach the end before the game is over

	// Creation of the game
	private void Awake() {
        DontDestroyOnLoad(gameObject);
        instance = this;
		grid = (Grid)transform.Find("Grid").gameObject.GetComponent("Grid");
		wave = (Wave)transform.Find("Wave").gameObject.GetComponent("Wave");
		lifes = 20;
		money = 50;
    }

	// Destruction of the game
	private void OnDestroy() {
        instance = null;
    }

	// Called once per frame
	private void Update () {
		if (Input.GetKeyDown("space")) {
			wave.Next();
			wavesText.text = "WAVE " + wave.number;
		}
		else if (Input.GetKeyDown("escape")) {
			currentTowerPrefab = null;
			highlight.GetComponent<SpriteRenderer>().enabled = false;
			infoTitleText.text = "";
			infoText.text = "";
		}
	}

	public void LoseLife() {
		lifes--;
		lifesText.text = "LIFES " + lifes;
	}

	public void updateMoney(int value) {
		money = value;
		moneyText.text = "MONEY " + money;
	}

	public void HighlightObject(Vector3 position) {
		highlight.GetComponent<SpriteRenderer>().enabled = true;
		highlight.transform.position = position;
	}

	public Waypoint GetWaypoint(int index) {
		return grid.GetWaypoint(index);
	}
}