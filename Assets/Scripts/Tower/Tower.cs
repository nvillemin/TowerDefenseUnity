using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	protected GameObject projectilePrefab;

	protected float cooldownMax;

	float cooldown; // Cooldown between shots
	List<Enemy> enemies; // Enemies in range of the tower

	// Tower creation
	public virtual void Awake () {
		enemies = new List<Enemy>();
		cooldown = 0f;
	}
	
	// Called once per frame
	void Update () {
		// Reduce the cooldown each frame
		if(cooldown > 0) {
			cooldown -= Time.deltaTime;
		}

		// Remove dead enemies
		for(int i=0; i<enemies.Count; ++i) {
			if(enemies[i] == null) {
				enemies.Remove(enemies[i]);
			}
		}

		// Fire the projectile
		if(enemies.Count > 0 && cooldown <= 0) {
			Projectile proj = (Projectile)((GameObject)Instantiate(projectilePrefab, new Vector3(this.transform.position.x, this.transform.position.y, 4f), Quaternion.identity)).GetComponent("Projectile");
			proj.SetTarget(enemies[0]); // Target first enemy
			cooldown = cooldownMax; // Projectile fired, reset cooldown
		}
	}

	// Object entering tower range
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy entering tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			this.enemies.Add(en);
		}
	}

	// Object leaving tower range
	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy leaving tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Remove(en);
		}
	}
}
