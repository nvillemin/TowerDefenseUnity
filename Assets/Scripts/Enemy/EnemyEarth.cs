using UnityEngine;
using System.Collections;

public class EnemyEarth : Enemy {
	
	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Elements.Earth] = 0.75f;
		elemDamage[(int)Elements.Air] = 1.25f;
		speed = 0.6f; // Earth enemies are slower than other enemies
	}

	public override void SetHealth(float health) {
		this.health = health * 1.2f; // Earth enemies have 20% more health than other enemies
	}
}
