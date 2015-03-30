using UnityEngine;
using System.Collections;

public class EnemyEarth : Enemy {
	
	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Global.Elements.Earth] = 0.75f;
		elemDamage[(int)Global.Elements.Air] = 1.25f;
		speed = 0.6f; // Earth enemies are slower than other enemies
		reward = 4;
	}

	public override void SetHealth(float health) {
		this.health = health * 1.2f; // Earth enemies have 20% more health than other enemies
	}
}
