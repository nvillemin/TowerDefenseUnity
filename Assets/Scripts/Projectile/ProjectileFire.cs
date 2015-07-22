using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileFire : Projectile {
	private DamageZone damageZone;

	// Initialization
	private void Awake () {
		element = (int)Global.Elements.Fire;
		speed = 2.0f;
//		effect = Global.Effects.None;
		damageZone = (DamageZone)transform.Find("DamageZone").gameObject.GetComponent("DamageZone");
	}

	// Colliding with another object
	protected override void OnTriggerEnter2D(Collider2D col) {
		// Colliding with an enemy
		if(col.gameObject.tag == "Enemy") {
			List<Enemy> enemies = damageZone.enemies; // Enemies receiving zone damage
			enemies.Remove(target); // Removing the main target because it already received full damage in Enemy.cs trigger function
			foreach(Enemy enemy in enemies) {
				// Checking if the enemy is still alive
				if(enemy != null) {
					float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
					if(distance == 0f) {
						enemy.TakeDamage(damage);
					} else {
						float newDamage = damage - distance * (damage / 1.0f);
						if(newDamage > 0f) {
							enemy.TakeDamage(newDamage);
						}
					}
				}
			}
			Destroy(gameObject); // Remove the projectile from the game
		}
	}
}
