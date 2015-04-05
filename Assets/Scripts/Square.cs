using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public Sprite squareSprite;

	private SpriteRenderer spriteRenderer;
	private Tower tower;

	private void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnMouseOver() { // Change this?
		if (Input.GetKeyDown("escape") && tower == null) {
			OnMouseExit();
		}
	}

	private void OnMouseEnter() {
		if (tower == null && Game.Instance.currentTowerPrefab != null) {
//			spriteRenderer.material.color -= new Color(0, 0, 0, 0.35f);
			spriteRenderer.sprite = Game.Instance.currentTowerPrefab.GetComponent<SpriteRenderer>().sprite;
			int elem = Game.Instance.currentTowerPrefab.GetComponent<Tower>().element;
			Game.Instance.DisplayRange(transform.position, Global.TowerStats[elem].range);
        }
    }

	private void OnMouseExit() {
		if (tower == null && Game.Instance.currentTowerPrefab != null) {
//			spriteRenderer.material.color += new Color(0, 0, 0, 0.35f);
			spriteRenderer.sprite = squareSprite;
			Game.Instance.rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

	private void OnMouseDown() {
		if (tower == null && Game.Instance.currentTowerPrefab != null) {
			int towerElement = Game.Instance.currentTowerPrefab.GetComponent<Tower>().GetElement();
			int towerPrice = Global.TowerStats[towerElement].price;
			if (towerPrice <= Game.Instance.money) {
				Game.Instance.UpdateMoney(Game.Instance.money - towerPrice);
				tower = (Tower)((GameObject)Instantiate(Game.Instance.currentTowerPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 6f), Quaternion.identity)).GetComponent("Tower");
				spriteRenderer.material.color -= new Color(0, 0, 0, spriteRenderer.material.color.a);
				Game.Instance.rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
			} else {
				// Show message not enough money
			}
		} else if (tower != null) {
			Game.Instance.SelectTower(tower);
		}
	}
}
