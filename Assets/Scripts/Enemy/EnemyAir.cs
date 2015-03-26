using UnityEngine;
using System.Collections;

public class EnemyAir : Enemy {
	
	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Elements.Air] = 0.75f;
		elemDamage[(int)Elements.Fire] = 1.25f;
		speed = 1f; // Air enemies are faster than other enemies
	}

	public override void SetHealth(float health) {
		this.health = health * 0.8f; // Air enemies have 20% less health than other enemies
	}
}
