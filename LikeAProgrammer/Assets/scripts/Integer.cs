using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integer : Enemy {

	private int value;

	public int getValue() {

		return value;
	}

	protected override float rotationAngleCompensation() {
		return 180.0f - 17.0f;
	}
}
