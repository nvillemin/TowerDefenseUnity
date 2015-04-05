using UnityEngine;
using System.Collections;

public class EnemyWater : Enemy {

	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Global.Elements.Water] = 0.75f;
		elemDamage[(int)Global.Elements.Earth] = 1.25f;
		//reward = 3;
	}
}
