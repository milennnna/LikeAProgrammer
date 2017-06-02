using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyType type;
	private Rigidbody2D rigidBody;
	public bool spawned = false;

	void Awake() {

		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setVelocity(Vector2 velocity) {

		rigidBody.velocity = velocity;
	}
}
