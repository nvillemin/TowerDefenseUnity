using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {
	public GameObject EnemyAirPrefab, EnemyFirePrefab, EnemyWaterPrefab, EnemyEarthPrefab;

	public int number; // Actual wave number

	private List<WaveConfig> wc; // List storing the config of all the different waves
	private int enemiesToSpawn; // Number of enemies left to spawn
	private Vector3 startPosition; // Starting position of the ennemies
	private float cooldown, cooldownMax; // Enemy spawning cooldown

	// Use this for initialization
	private void Start () {
		number = 0;
		enemiesToSpawn = 0;
		startPosition = Game.Instance.GetWaypoint(0).transform.position;
		cooldown = 0f;
		cooldownMax = 1.0f;

		// Initialize all waves (count, prefab, health)
		wc = new List<WaveConfig> {
			new WaveConfig(20, EnemyAirPrefab, 20.0f), // Wave 1
			new WaveConfig(20, EnemyFirePrefab, 30.0f), // Wave 2
			new WaveConfig(20, EnemyWaterPrefab, 45.0f), // Wave 3
			new WaveConfig(20, EnemyEarthPrefab, 75.0f)  // Wave 4
		};
	}

	// Called once per frame
	private void Update () {
		if(enemiesToSpawn > 0) {
			// Reduce the cooldown each frame
			if(cooldown > 0) {
				cooldown -= Time.deltaTime;
			}
			// Spawn an enemy
			else {
				Enemy enemy = (Enemy)((GameObject)Instantiate(wc[number-1].prefab, startPosition, Quaternion.identity)).GetComponent("Enemy");
				enemy.SetHealth(wc[number-1].health);
				enemiesToSpawn--;
				if(enemiesToSpawn == 0) {
					cooldown = 0f;
				}
				else {
					cooldown = cooldownMax;
				}
			}
		}
	}

	// Start the next wave of ennemies
	public void Next() {
		if(number < wc.Count && enemiesToSpawn == 0) {
			number++;
			enemiesToSpawn = wc[number-1].count;
		}
	}
}
