using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public float speed = 4;
	public Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(0.0f, 0.0f, -10.0f);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(0.0f, 0.0f, 10.0f);
		}
	}

	void FixedUpdate() {
		//rigidBody.MoveRotation (rigidBody.rotation + speed * Time.fixedDeltaTime);
	}
}
