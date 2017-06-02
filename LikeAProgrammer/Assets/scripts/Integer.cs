using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integer : Enemy {

	private int value;
	public Sprite[] sprites;

	public int getValue() {

		return value;
	}

	void Start() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprites[Random.Range(0, 10)];
	}
}
