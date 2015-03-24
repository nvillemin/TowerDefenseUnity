using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    public GameObject squarePrefab, waypointPrefab;

    Square[,] squares; // All the squares for tower creation are stored here
    List<Waypoint> waypoints; // List of the waypoints used by the enemies to reach the end
    int width, height; // Width and height of the grid (number of squares)
	
	// Grid creation
	void Awake () {
		width = 16;
        height = 14;
		squares = new Square[width, height];

        CreateSquares();
	}

	// Creation of the squares
	void CreateSquares() {
		bool[,] path;
		path = new bool[width, height];

		// Storing where squares shouldn't be created, allowing a path for the enemies
		for (int i = 2; i < 14; ++i) {
			if(i < 4) {
				path[i, 0] = true;
				path[i, 1] = true;
				path[i, 8] = true;
				path[i, 9] = true;
			}
			if(i > 11) {
				path[i, 4] = true;
				path[i, 5] = true;
				path[i, 12] = true;
				path[i, 13] = true;
			}
			path[i, 2] = true;
			path[i, 3] = true;
			path[i, 6] = true;
			path[i, 7] = true;
			path[i, 10] = true;
			path[i, 11] = true;
		}

		// Creating squares
		for (int i = 0; i < width; ++i) {
			for (int j = 0; j < height; ++j) {
				if(!path[i, j]) {
					squares[i, j] = (Square)((GameObject)Instantiate(squarePrefab, new Vector3(0.2f + (float)i * 0.4f, -0.6f + (float)j * -0.4f, 5f), Quaternion.identity)).GetComponent("Square");
				}
			}
		}

		// Initialization of the waypoints positions
		List<Vector3> wpPositions = new List<Vector3> {
			new Vector3(1.20f, -0.42f, 4f), // Waypoint 0
			new Vector3(1.20f, -1.67f, 4f), // Waypoint 1
			new Vector3(5.27f, -1.60f, 4f), // Waypoint 2
			new Vector3(5.20f, -3.27f, 4f), // Waypoint 3
			new Vector3(1.13f, -3.20f, 4f), // Waypoint 4
			new Vector3(1.20f, -4.87f, 4f), // Waypoint 5
			new Vector3(5.27f, -4.80f, 4f), // Waypoint 6
			new Vector3(5.20f, -6.00f, 4f)  // Waypoint 7
		};

		// Creating the waypoints for the enemies
		waypoints = new List<Waypoint>();
		for (int i = 0; i < wpPositions.Count; ++i) {
			waypoints.Add((Waypoint)((GameObject)Instantiate(waypointPrefab, wpPositions[i], Quaternion.identity)).GetComponent("Waypoint"));
			waypoints[i].index = i;
		}
	}

	// Return a waypoint at a precise index
    public Waypoint GetWaypoint(int index) {
        if (index >= waypoints.Count)
            return null;
        return waypoints[index];
    }
}
