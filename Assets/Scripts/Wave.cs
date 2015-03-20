using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {
	public GameObject enemyNormalPrefab;

	public int number { get; private set; } // Actual wave number

	List<WaveConfig> wc; // List storing the config of all the different waves
	int enemiesToSpawn; // Number of enemies left to spawn
	Vector3 startPosition; // Starting position of the ennemies
	float cooldown, cooldownMax; // Enemy spawning cooldown

	// Use this for initialization
	void Start () {
		number = 0;
		enemiesToSpawn = 0;
		startPosition = Game.Instance.GetWaypoint(0).transform.position;
		cooldown = 0f;
		cooldownMax = 1.0f;

		// Initialize all waves (count, prefab, health)
		wc = new List<WaveConfig> {
			new WaveConfig(20, enemyNormalPrefab, 100.0f) // Wave 0
		};
	}

	// Called once per frame
	void Update () {
		if(enemiesToSpawn > 0) {
			// Reduce the cooldown each frame
			if(cooldown > 0) {
				cooldown -= Time.deltaTime;
			}
			// Spawn an enemy
			else {
				Enemy enemy = (Enemy)((GameObject)Instantiate(wc[number].prefab, startPosition, Quaternion.identity)).GetComponent("Enemy");
				enemy.SetHealth(wc[number].health);
				enemiesToSpawn--;
				if(enemiesToSpawn == 0) {
					number++;
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
		if(number < wc.Count) {
			enemiesToSpawn = wc[number].count;
		}
	}
}
