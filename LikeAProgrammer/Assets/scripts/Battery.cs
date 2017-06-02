using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Battery : Enemy {

	public bool value;

	public static bool batteryValue() {

		return ((int)Random.Range (0, 2) == 1);
	}
		
	protected override bool rotateToVelocity () {
		return false;
	}

	void Start() {
		int direction = ((int)Random.Range (0, 2) == 1) ? 1 : -1;
		float intensity = Random.Range (40, 60);
		rigidBody.angularVelocity = direction * intensity;
	}
}
