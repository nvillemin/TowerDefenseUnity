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

		// Initialize all waves (count, prefab, health, cooldown)
		wc = new List<WaveConfig>();
		int enemyCount = 20;
		float health = 20.0f;
		float cd = 1.0f;
		GameObject prefab = null;
		for (int i=0; i<200; ++i) {
			switch(i % 4) {
			case 0:
				prefab = EnemyAirPrefab;
				break;
			case 1:
				prefab = EnemyFirePrefab;
				break;
			case 2:
				prefab = EnemyWaterPrefab;
				break;
			case 3:
				prefab = EnemyEarthPrefab;
				break;
			}
			wc.Add(new WaveConfig(enemyCount, prefab, health, cd));
			health = (health + 10f) * 1.1f;
			if(enemyCount < 100) {
				enemyCount += 2;
			}
			cd = 20f / enemyCount;
		}
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
			cooldownMax = wc[number-1].cooldown;
			enemiesToSpawn = wc[number-1].count;
		}
	}
}
