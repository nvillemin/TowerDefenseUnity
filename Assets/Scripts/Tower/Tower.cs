using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Tower : MonoBehaviour {
	public int element;
	public string effect { get; private set; } // Special effect of the tower
	public string type { get; private set; } // Type of the tower

	protected GameObject projectilePrefab;
	protected float cooldownMax, damage;

	private float cooldown; // Cooldown between shots
	private List<Enemy> enemies; // Enemies in range of the tower

	
	// Tower creation
	public virtual void Awake () {
		transform.GetComponent<CircleCollider2D>().radius = Global.TowerStats[element].range; // Maximum range to target enemies
		cooldownMax = Global.TowerStats[element].cooldown;
		damage = Global.TowerStats[element].damage;
		enemies = new List<Enemy>();
		cooldown = 0f;
		effect = Global.TowerStats[element].effect;
		type = Global.TowerStats[element].name;
	}
	
	// Called once per frame
	private void Update () {
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
			proj.damage = this.damage;
			proj.target = enemies[0]; // Target first enemy
			cooldown = cooldownMax; // Projectile fired, reset cooldown
		}
	}

	// Object entering tower range
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy entering tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Add(en);
		}
	}

	// Object leaving tower range
	private void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy leaving tower range
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Remove(en);
		}
	}

	public int GetElement() { return this.element; }
	public float GetDamage() { return this.damage; }
	public float GetCooldown() { return this.cooldownMax; }
}
