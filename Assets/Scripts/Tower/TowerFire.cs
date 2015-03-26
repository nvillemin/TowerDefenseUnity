using UnityEngine;
using System.Collections;

public class TowerFire : Tower {
	public GameObject projectile;

	// Tower creation
	public override void Awake () {
		base.Awake();
		base.projectilePrefab = projectile;
		transform.GetComponent<CircleCollider2D>().radius = 1.4f; // Maximum range to target enemies
		cooldownMax = 1.0f;
		damage = 15f;
	}
}
