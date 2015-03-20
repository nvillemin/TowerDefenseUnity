using UnityEngine;
using System.Collections;

public class EnemyNormal : Enemy {

	// Initialization
	public override void Awake () {
		base.Awake();
		speed = 0.8f;
	}
}
