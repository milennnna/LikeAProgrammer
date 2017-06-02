using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Enemy {

	private string value;
	public Sprite[] sprites;

	public string getValue() {

		return value;
	}

	void Start() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprites[Random.Range(0, 26)];
	}
}
