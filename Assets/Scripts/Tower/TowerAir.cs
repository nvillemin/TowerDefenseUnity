using UnityEngine;
using System.Collections;

public class TowerAir : Tower {
	public GameObject projectile;
	
	// Tower creation
	public override void Awake () {
		base.Awake();
		base.projectilePrefab = projectile;
		transform.GetComponent<CircleCollider2D>().radius = 1.2f; // Maximum range to target enemies
		cooldownMax = 0.25f;
		damage = 5f;
	}
}
