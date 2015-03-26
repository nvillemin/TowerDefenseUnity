using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage { get; set; }

	Enemy target;
	float speed;

	// Initialization
	void Awake () {
		speed = 1.5f;
		damage = 25f;
	}
	
	// Called once per frame
	void Update () {
		// The target is still alive
		if(target != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
		}
		// No more target
		else {
			Destroy(gameObject); // Remove the projectile from the game
		}
	}

	// Colliding with another object
	void OnTriggerEnter2D(Collider2D col) {
		// Colliding with an enemy
		if(col.gameObject.tag == "Enemy") {
			Destroy(gameObject); // Remove the projectile from the game
		}
	}

	// Set the target of the projectile
	public void SetTarget(Enemy enemy) {
		target = enemy;
	}
}
