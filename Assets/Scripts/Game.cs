using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    static Game instance;
    public static Game Instance { get { return instance; } }
    public GameObject gridPrefab, enemyPrefab;

    Grid grid; // The grid of the game, containing the path and tower locations
    Enemy enemyTest; // Enemy only used for testing, remove this for final version

	// Creation of the game
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

	// Destruction of the game
    void OnDestroy() {
        instance = null;
    }

	// Initialization
	void Start () {
        grid = (Grid)((GameObject)Instantiate(gridPrefab, new Vector3(0, 0, 5), Quaternion.identity)).GetComponent("Grid");
        enemyTest = (Enemy)((GameObject)Instantiate(enemyPrefab, grid.GetWaypoint(0).transform.position, Quaternion.identity)).GetComponent("Enemy");
	}
	
	// Called once per frame
	void Update () {
	
	}

    public Waypoint GetWaypoint(int index) {
        return grid.GetWaypoint(index);
    }

	public void LoseLife(Enemy en) {
		Destroy(en);
		// Add stuff to lower life count
	}
}