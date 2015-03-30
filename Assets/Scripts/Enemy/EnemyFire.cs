using UnityEngine;
using System.Collections;

public class EnemyFire : Enemy {

	// Initialization
	public override void Awake () {
		base.Awake();
		elemDamage[(int)Global.Elements.Fire] = 0.75f;
		elemDamage[(int)Global.Elements.Water] = 1.25f;
		reward = 2;
	}
}
