using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public GameObject towerRedPrefab, towerBluePrefab;
	public Sprite squareSprite;

	GameObject currentTowerPrefab;
	SpriteRenderer spriteRenderer;
    Tower tower;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnMouseOver() { // Change this?
		if (tower == null && Input.GetKeyDown("escape")) {
			OnMouseExit();
		}
	}

    void OnMouseEnter() {
		if (tower == null && Game.Instance.towerSelection != "None") {
			spriteRenderer.material.color -= new Color(0, 0, 0, 0.35f);
			SetCurrentTower();
			spriteRenderer.sprite = currentTowerPrefab.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void OnMouseExit() {
		if (tower == null && Game.Instance.towerSelection != "None") {
			spriteRenderer.material.color += new Color(0, 0, 0, 0.35f);
			spriteRenderer.sprite = squareSprite;
        }
    }

	void OnMouseDown() {
		if (tower == null && Game.Instance.towerSelection != "None") {
			SetCurrentTower();
			tower = (Tower)((GameObject)Instantiate(currentTowerPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 6f), Quaternion.identity)).GetComponent("Tower");
			spriteRenderer.material.color -= new Color(0, 0, 0, spriteRenderer.material.color.a);
		}
	}

	void SetCurrentTower() {
		switch(Game.Instance.towerSelection) {
		case "Red":
			currentTowerPrefab = towerRedPrefab;
			break;
		case "Blue":
			currentTowerPrefab = towerBluePrefab;
			break;
		}
	}
}
