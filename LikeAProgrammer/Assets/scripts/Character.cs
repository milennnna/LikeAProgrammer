using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Enemy {

	private string value;
	public Sprite[] sprites;

	public string getValue() {

		return value;
	}

	protected override float rotationAngleCompensation() {
		return 180.0f - 17.0f;
	}

	void Start() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprites[Random.Range(0, 26)];
	}
}
