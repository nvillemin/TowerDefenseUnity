using UnityEngine;
using System.Collections;

public class EnemyWater : Enemy {

	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Elements.Water] = 0.75f;
		elemDamage[(int)Elements.Earth] = 1.25f;
	}
}
