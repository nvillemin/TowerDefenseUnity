using UnityEngine;
using System.Collections;

public class WaveConfig {
	public int count { get; private set; }
	public GameObject prefab { get; private set; }
	public float health { get; private set; }

	public WaveConfig(int count, GameObject prefab, float health) {
		this.count = count;
		this.prefab = prefab;
		this.health = health;
	}
}
