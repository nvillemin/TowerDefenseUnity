using UnityEngine;
using System.Collections;

public class ProjectileAir : Projectile {

	// Initialization
	private void Awake () {
		element = (int)Global.Elements.Air;
		speed = 3.0f;
	}
}
