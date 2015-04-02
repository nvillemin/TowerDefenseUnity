using UnityEngine;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour {
	protected float speed, health, healthMax; // healthMax is used to show a percentage of the health bar
	protected float[] elemDamage; // Resistance against elements. (default 1.0->100% damage; 0.75->75% damage etc.)
	protected int reward;

	private int waypointIndex; // Index of the next waypoint
	private Waypoint nextWaypoint; // Next waypoint to reach
	private GameObject healthBar;

	// Initialization
	public virtual void Awake () {
		elemDamage = new float[4] { 1f, 1f, 1f, 1f };
		health = 1f;
		speed = 0.8f;
        waypointIndex = 1;
        nextWaypoint = Game.Instance.GetWaypoint(1);
		healthBar = (GameObject)Instantiate(Game.Instance.healthBarPrefab, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
	}

	// Called once per frame
	private void Update () {
		// Still hasn't reached the last waypoint
		if(nextWaypoint != null) {
			transform.Rotate(Vector3.back, 2); // Rotate animation
			Move();
			healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z - 1.0f);
		}
		// The last checkpoint has been reached
		else {
			Game.Instance.LoseLife(); // Trigger the game function to lose a life
			Destroy(healthBar);
			Destroy(gameObject); // Remove the enemy from the game
		}
	}

	// Colliding with another object
	private void OnTriggerEnter2D(Collider2D col) {
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
				Destroy(healthBar); // Remove the health bar from the game
				Destroy(gameObject); // Remove the enemy from the game
				Game.Instance.updateMoney(Game.Instance.money + reward);
			}
			else {
				health -= proj.damage;
				healthBar.transform.localScale = new Vector3(health / healthMax, 1, 1);
			}
			break;
		}
	}

	// Move to the next checkpoint
	private void Move() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.transform.position, step);
	}

	public virtual void SetHealth(float health) {
		this.healthMax = health;
		this.health = health;
	}
}
