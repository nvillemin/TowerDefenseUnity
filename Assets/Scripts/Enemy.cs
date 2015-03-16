using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    int waypointIndex; // Index of the next waypoint
	Waypoint nextWaypoint; // Next waypoint to reach

	// Initialization
	void Awake () {
        waypointIndex = 1;
        nextWaypoint = Game.Instance.GetWaypoint(1);
	}
	
	// Called once per frame
	void Update () {
		if(nextWaypoint != null) {
			transform.Rotate(Vector3.back, 2); // Rotate animation
			Move();
		}
		else {
			Game.Instance.LoseLife(this);
		}
	}

	// Move to the next checkpoint
    void Move() {
        if (transform.position.x < nextWaypoint.transform.position.x)
            transform.Translate(new Vector3(0.01f, 0, 0), Space.World);
        if (transform.position.x > nextWaypoint.transform.position.x)
            transform.Translate(new Vector3(-0.01f, 0, 0), Space.World);
        if (transform.position.y < nextWaypoint.transform.position.y)
            transform.Translate(new Vector3(0, 0.01f, 0), Space.World);
        if (transform.position.y > nextWaypoint.transform.position.y)
            transform.Translate(new Vector3(0, -0.01f, 0), Space.World);
    }

//	public void SetNextWaypoint() {
//    	waypointIndex++;
//    	this.nextWaypoint = Game.Instance.GetWaypoint(waypointIndex);
//		print("SetNextWaypoint - Next checkpoint reached! New next = " + waypointIndex);
//    }

	void OnTriggerEnter2D(Collider2D col) {
//		print("TriggerENEMY"); // Print for debug
		
		if (col.gameObject.tag == "Waypoint") {
			Waypoint wp = col.gameObject.GetComponent<Waypoint>();
//			print ("col is waypoint, index = " + wp.index);
			if(wp.index == waypointIndex) {
				waypointIndex++;
				nextWaypoint = Game.Instance.GetWaypoint(waypointIndex);
//				print("SetNextWaypoint - Next checkpoint reached! New next = " + waypointIndex);
			}
		}
	}
}
