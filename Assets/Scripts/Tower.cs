using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	public GameObject projectilePrefab;

	int cooldown, cooldownMax; // Cooldown between shots
	List<Projectile> projectiles; // Projectiles that have been fired by the tower
	List<Enemy> enemies; // Enemies in range of the tower

	// Tower creation
	void Awake () {
		transform.GetComponent<CircleCollider2D>().radius = 1.5f; // Maximum range to target enemies
		cooldown = 0;
		cooldownMax = 50;
		projectiles = new List<Projectile>();
		enemies = new List<Enemy>();
	}
	
	// Called once per frame
	void Update () {
//		print ("Cooldown = " + cooldown);
		if(cooldown > 0) {
			cooldown--;
		}
		if(enemies.Count > 0) {
			print ("enemies.Count = " + enemies.Count);
			if(cooldown == 0) {
				Projectile proj = (Projectile)((GameObject)Instantiate(projectilePrefab, this.transform.position, Quaternion.identity)).GetComponent("Projectile");
				proj.SetTarget(enemies[0]); // TARGET FIRST ENEMY, CHANGE THIS
				projectiles.Add(proj);
				cooldown = cooldownMax;
			}
		}
	}

	// Object entering tower range
	void OnTriggerEnter2D(Collider2D col) {
		print ("OnTriggerEnter2D TOWER");
		if (col.gameObject.tag == "Enemy") { // Enemy entering tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			this.enemies.Add(en);
		}
	}

	// Object leaving tower range
	void OnTriggerExit2D(Collider2D col) {
		print ("OnTriggerExit2D TOWER");
		if (col.gameObject.tag == "Enemy") { // Enemy leaving tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Remove(en);
		}
	}
}
