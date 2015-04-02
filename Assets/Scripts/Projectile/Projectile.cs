using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
	public Enemy target { get; set; }
	public float damage { get; set; }

	protected int element;
	protected float speed;

	// Called once per frame
	private void Update () {
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
	protected virtual void OnTriggerEnter2D(Collider2D col) {
		// Colliding with an enemy
		if(col.gameObject.tag == "Enemy") {
			Destroy(gameObject); // Remove the projectile from the game
		}
	}

	public int GetElement() { return this.element; }
}
