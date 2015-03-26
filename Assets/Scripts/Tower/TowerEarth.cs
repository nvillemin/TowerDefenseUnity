using UnityEngine;
using System.Collections;

public class TowerEarth : Tower {
	public GameObject projectile;
	
	// Tower creation
	public override void Awake () {
		base.Awake();
		base.projectilePrefab = projectile;
		transform.GetComponent<CircleCollider2D>().radius = 1.7f; // Maximum range to target enemies
		cooldownMax = 2.0f;
		damage = 40f;
	}
}
