﻿using UnityEngine;
using System.Collections;

public static class Global {
	// Structure of a tower
	public struct TowerStruct {
		public string name { get; private set; }
		public string effect { get; private set; }
		public int price { get; private set; }
		public float damage { get; private set; }
		public float cooldown { get; private set; }
		public float range { get; private set; }

		public TowerStruct(string name, int price, float damage, float cooldown, float range, string effect) {
			this.name = name;
			this.effect = effect;
			this.price = price;
			this.damage = damage;
			this.cooldown = cooldown;
			this.range = range;
		}
	};

	// All the elements of the game are listed here
	public enum Elements{
		Air,
		Fire,
		Water,
		Earth
	};

	// Stats of all available towers
	public static TowerStruct[] TowerStats = {
		//				NAME			PRICE	DAMAGE	COOLDOWN	RANGE	EFFECT
		new TowerStruct("Air Tower",	15,		5f,		0.25f, 		1.2f,	"None"),
		new TowerStruct("Fire Tower",	15,		15f,	1.0f, 		1.4f,	"AOE"),
		new TowerStruct("Water Tower",	15,		5f,		1.0f, 		1.0f,	"None yet"),
		new TowerStruct("Earth Tower",	15,		40f,	2.0f, 		1.7f, 	"None")
	};
}