using UnityEngine;
using System.Collections;

public class ProjectileEarth : Projectile {

	// Initialization
	private void Awake () {
		element = (int)Global.Elements.Earth;
		speed = 1.5f;
		transform.localScale = new Vector3(1.5f, 1.5f, 1);
	}
}
