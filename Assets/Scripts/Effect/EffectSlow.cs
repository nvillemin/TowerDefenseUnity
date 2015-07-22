using UnityEngine;
using System.Collections;

public class EffectSlow : Effect {

	// Use this for initialization
	private void Awake () {
		this.id = (int)Global.Effects.Slow;
		this.duration = 4.0f;
	}

	protected override void TurnOn () {
		this.target.speed *= 0.6f;
	}

	protected override void TurnOff () {
		this.target.speed /= 0.6f;
		Destroy(gameObject);
	}
}
