using UnityEngine;
using System.Collections;

public class TowerSelection : MonoBehaviour {
	public GameObject TowerAirPrefab, TowerFirePrefab, TowerWaterPrefab, TowerEarthPrefab;

	// Selection of the tower to place
	private void OnMouseDown() {
		Game.Instance.HighlightObject(transform.position, 0.8f);
		Game.Instance.rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
		SetCurrentTower();
		SetTextInfo();
	}

	// Sets the prefab of the selected tower
	private void SetCurrentTower() {
		switch(name) {
		case "Air":
			Game.Instance.currentTowerPrefab = TowerAirPrefab;
			break;
		case "Fire":
			Game.Instance.currentTowerPrefab = TowerFirePrefab;
			break;
		case "Water":
			Game.Instance.currentTowerPrefab = TowerWaterPrefab;
			break;
		case "Earth":
			Game.Instance.currentTowerPrefab = TowerEarthPrefab;
			break;
		}
	}

	// Update the information text to show the tower stats
	private void SetTextInfo() {
		int elem = Game.Instance.currentTowerPrefab.GetComponent<Tower>().element;
		Game.Instance.infoTitleText.text = Global.TowerStats[elem].name;
		Game.Instance.infoText.text = "PRICE: " + Global.TowerStats[elem].price + "\n";
		Game.Instance.infoText.text += "DAMAGE: " + Global.TowerStats[elem].damage + "\n";
		Game.Instance.infoText.text += "COOLDOWN: " + Global.TowerStats[elem].cooldown + "s" + "\n";
		Game.Instance.infoText.text += "RANGE: " + Global.TowerStats[elem].range + "\n\n";
		Game.Instance.infoText.text += "EFFECT: " + Global.TowerStats[elem].effect + "\n";
	}
}
