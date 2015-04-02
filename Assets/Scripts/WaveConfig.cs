using UnityEngine;
using System.Collections;

public class WaveConfig {
	public int count { get; private set; }
	public GameObject prefab { get; private set; }
	public float health { get; private set; }
	public float cooldown { get; private set; }

	public WaveConfig(int count, GameObject prefab, float health, float cooldown) {
		this.count = count;
		this.prefab = prefab;
		this.health = health;
		this.cooldown = cooldown;
	}
}
