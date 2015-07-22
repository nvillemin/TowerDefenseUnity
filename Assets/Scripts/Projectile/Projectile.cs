using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
	public Enemy target { get; set; }
	public float damage { get; set; }
	public Effect effect { get; protected set; }
	public int element { get; protected set; }

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
			Remove();
		}
	}

	// Colliding with another object
	protected virtual void OnTriggerEnter2D(Collider2D col) {
		// Colliding with an enemy
		if(col.gameObject.tag == "Enemy") {
			Remove(); 
		}
	}

	// Remove the projectile from the game
	private void Remove() {
		if(this.effect != null && !this.effect.active) {
			Destroy(this.effect.gameObject);
		}
		Destroy(gameObject);
	}
}
