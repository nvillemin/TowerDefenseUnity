using UnityEngine;
using System.Collections;

public class TowerRed : Tower {
	public GameObject projectile;

	// Tower creation
	public override void Awake () {
		base.Awake();
		base.projectilePrefab = projectile;
		transform.GetComponent<CircleCollider2D>().radius = 1.5f; // Maximum range to target enemies
		cooldownMax = 0.5f;
	}
}
