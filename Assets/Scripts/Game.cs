using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
	public GameObject currentTowerPrefab { get; set; }
	public GUIText lifesText, wavesText, moneyText, infoTitleText, infoText;
	public GameObject highlight; // Yellow highlight sprite for selections
	public GameObject rangeIndicator; // Range indicator sprite for selections
	public int money; // Money available for towers
	public GameObject healthBarPrefab;
	public Wave wave { get; private set; } // The actual wave of ennemies
	public GameObject startButton;

    private Grid grid; // The grid of the game, containing the path and tower locations
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
			StartWave();
		}
		else if (Input.GetKeyDown("escape")) {
			currentTowerPrefab = null;
			highlight.GetComponent<SpriteRenderer>().enabled = false;
			rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
			infoTitleText.text = "";
			infoText.text = "";
		}
	}

	// Start a new wave
	public void StartWave() {
		startButton.GetComponent<Button>().interactable = false;
		wave.Next();
		wavesText.text = "WAVE " + wave.number;
	}

	public void LoseLife() {
		lifes--;
		lifesText.text = "LIFES " + lifes;
	}

	public void UpdateMoney(int value) {
		money = value;
		moneyText.text = "MONEY " + money;
	}

	public void HighlightObject(Vector3 position, float scale) {
		highlight.transform.position = position;
		highlight.transform.localScale = new Vector3(scale, scale, scale);
		highlight.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void SelectTower(Tower tower) {
		HighlightObject(new Vector3(tower.transform.position.x, tower.transform.position.y, 1.5f), 1.0f);
		DisplayRange(tower.transform.position, tower.GetComponent<CircleCollider2D>().radius);
		currentTowerPrefab = null;
		infoTitleText.text = tower.type;
		infoText.text = "DAMAGE: " + tower.GetDamage() + "\n";
		infoText.text += "COOLDOWN: " + tower.GetCooldown() + "s" + "\n";
		infoText.text += "RANGE: " + tower.GetComponent<CircleCollider2D>().radius + "\n\n";
		infoText.text += "EFFECT: " + tower.effect + "\n";
	}

	public void DisplayRange(Vector3 position, float range) {
		rangeIndicator.transform.position = new Vector3(position.x, position.y, 1.5f);
		rangeIndicator.transform.localScale = new Vector3(range, range, 1.0f);
		rangeIndicator.GetComponent<SpriteRenderer>().enabled = true;
	}

	public Waypoint GetWaypoint(int index) {
		return grid.GetWaypoint(index);
	}
}