﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	protected float speed, health; // Movement speed and health of the enemy
    int waypointIndex; // Index of the next waypoint
	Waypoint nextWaypoint; // Next waypoint to reach

	// Initialization
	public virtual void Awake () {
        waypointIndex = 1;
        nextWaypoint = Game.Instance.GetWaypoint(1);
	}

	// Called once per frame
	protected void Update () {
		// Still hasn't reached the last waypoint
		if(nextWaypoint != null) {
			transform.Rotate(Vector3.back, 2); // Rotate animation
			Move();
		}
		// The last checkpoint has been reached
		else {
			Game.Instance.LoseLife(); // Trigger the game function to lose a life
			Destroy(gameObject); // Remove the enemy from the game
		}
	}

	// Colliding with another object
	void OnTriggerEnter2D(Collider2D col) {
		switch(col.gameObject.tag) {
		// Colliding with a waypoint
		case "Waypoint":
			Waypoint wp = col.gameObject.GetComponent<Waypoint>();
			
			// The next waypoint has been reached
			if(wp.index == waypointIndex) {
				waypointIndex++;
				nextWaypoint = Game.Instance.GetWaypoint(waypointIndex);
			}
			break;

		// Colliding with a projectile
		case "Projectile":
			Projectile proj = col.gameObject.GetComponent<Projectile>();

			// The projectile damage is higher than the health of the enemy
			if(health <= proj.damage) {
				Destroy(gameObject); // Remove the enemy from the game
			}
			else {
				health -= proj.damage;
			}
			break;
		}
	}

	// Move to the next checkpoint
	void Move() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.transform.position, step);
	}

	public void SetHealth(float health) {
		this.health = health;
	}
}