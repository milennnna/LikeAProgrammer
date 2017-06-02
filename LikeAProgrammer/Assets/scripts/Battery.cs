using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Battery : Enemy {

	public bool value;

	public static bool batteryValue() {

		return ((int)Random.Range (0, 2) == 1);
	}
}
