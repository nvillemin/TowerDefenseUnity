using UnityEngine;
using System.Collections;

public class TowerAir : Tower {
	public GameObject projectile;

	// Tower creation
	public override void Awake () {
		base.Awake();
		base.projectilePrefab = projectile;
	}
}
