using UnityEngine;
using System.Collections;

public class ProjectileWater : Projectile {
	public GameObject effectPrefab;

	// Initialization
	private void Awake () {
		element = (int)Global.Elements.Water;
		speed = 2.0f;
		effect = (Effect)((GameObject)Instantiate(effectPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 4f), Quaternion.identity)).GetComponent("Effect");
	}
}
