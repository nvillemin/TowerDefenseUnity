using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	Enemy target;
	float speed;

	// Initialization
	void Awake () {
		speed = 2.0f;
	}
	
	// Called once per frame
	void Update () {
		if(target != null) {
			// VERY BASIC MOVEMENT, CHANGE THIS
			if (transform.position.x < target.transform.position.x)
				transform.Translate(new Vector3(0.01f * speed, 0, 0), Space.World);
			if (transform.position.x > target.transform.position.x)
				transform.Translate(new Vector3(-0.01f * speed, 0, 0), Space.World);
			if (transform.position.y < target.transform.position.y)
				transform.Translate(new Vector3(0, 0.01f * speed, 0), Space.World);
			if (transform.position.y > target.transform.position.y)
				transform.Translate(new Vector3(0, -0.01f * speed, 0), Space.World);
		}
	}

	// Set the target of the projectile
	public void SetTarget(Enemy en) {
		target = en;
	}
}
