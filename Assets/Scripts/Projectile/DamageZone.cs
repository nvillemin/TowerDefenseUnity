using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageZone : MonoBehaviour {
	public List<Enemy> enemies { get; private set; } // Enemies in the damage zone

	// Use this for initialization
	private void Awake () {
		enemies = new List<Enemy>();
	}

	// Object entering damage zone
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy entering zone
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Add(en);
		}
	}

	// Object leaving damage zone
	private void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") { // Enemy leaving damage zone
			Enemy en = col.gameObject.GetComponent<Enemy>();
			enemies.Remove(en);
		}
	}
}
