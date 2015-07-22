using UnityEngine;
using System.Collections;

public abstract class Effect : MonoBehaviour {
	protected Enemy target;
	private float startTime;
	public bool active { get; private set; }
	protected float duration;
	public int id { get; protected set; }
	
	// Update is called once per frame
	private void Update () {
		if(this.active && Time.realtimeSinceStartup >= this.startTime + this.duration) {
			this.TurnOff();
		}
	}

	public void Activate(Enemy target) {
		this.target = target;
		this.startTime = Time.realtimeSinceStartup;
		this.active = true;
		this.TurnOn();
	}

	public void Reset() {
		this.startTime = Time.realtimeSinceStartup;
	}

	protected abstract void TurnOn();
	protected abstract void TurnOff();
}