using UnityEngine;
using System.Collections;

public class ProjectileWater : Projectile {

	// Initialization
	private void Awake () {
		element = (int)Global.Elements.Water;
		speed = 2.0f;
	}
}
