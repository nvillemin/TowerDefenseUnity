using UnityEngine;
using System.Collections;

public class EnemySprite : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back, 2); // Rotate animation
	}
}
