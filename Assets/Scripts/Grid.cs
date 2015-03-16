using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    public GameObject squarePrefab, waypointPrefab;

    Square[,] squares;
    List<Waypoint> waypoints;
    int nbSquaresX, nbSquaresY; // Width and height of the grid
	
	// Grid creation
	void Awake () {
        nbSquaresX = 20;
        nbSquaresY = 15;
        squares = new Square[nbSquaresX, nbSquaresY];

        for (int i = 0; i < nbSquaresX; ++i) {
            for (int j = 0; j < nbSquaresY; ++j) {
                squares[i, j] = (Square)((GameObject)Instantiate(squarePrefab, new Vector3(0.05f + (float)i * 0.4f, -0.02f + (float)j * -0.4f, 5), Quaternion.identity)).GetComponent("Square");
            }
        }

        CreatePath();
	}

    // Called once per frame
    void Update() {
	
	}

	// Creation of the path for the enemies
    void CreatePath() {
        for (int i = 0; i < 4; ++i) {
            squares[2, i].SetPath();
            squares[3, i].SetPath();
        }
        for (int i = 4; i < 16; ++i) {
            squares[i, 2].SetPath();
            squares[i, 3].SetPath();
        }
        for (int i = 2; i < 8; ++i) {
            squares[16, i].SetPath();
            squares[17, i].SetPath();
        }
        for (int i = 2; i < 16; ++i) {
            squares[i, 6].SetPath();
            squares[i, 7].SetPath();
        }
        for (int i = 8; i < 12; ++i) {
            squares[2, i].SetPath();
            squares[3, i].SetPath();
        }
        for (int i = 4; i < 18; ++i) {
            squares[i, 10].SetPath();
            squares[i, 11].SetPath();
        }
        for (int i = 12; i < 15; ++i) {
            squares[16, i].SetPath();
            squares[17, i].SetPath();
        }

		waypoints = new List<Waypoint>();
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[3, 0].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[3, 3].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[17, 3].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[17, 7].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[3, 7].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[3, 11].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[17, 11].transform.position, Quaternion.identity)).GetComponent("Waypoint"));
        waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, squares[17, 14].transform.position - new Vector3(0,0.4f,0), Quaternion.identity)).GetComponent("Waypoint"));
	
		for (int i = 0; i < waypoints.Count; ++i) {
			waypoints[i].index = i;
		}
	}

    public Waypoint GetWaypoint(int index) {
        if (index >= waypoints.Count)
            return null;
        return waypoints[index];
    }
}
