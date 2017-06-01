using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

	public float maxSpeed;
	public float minSpeed;
	public float maxSpin;
	public float timeStepDuration;
	public GameObject laika;

	private GameObject[] reusableEnemyPool;
	private int[] scheduledCollisionTimes;

	enum EnemyType {

		Battery,
		Character,
		Integer
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnEnemy(float speed, float spin, EnemyType type, int spawnTime) {

	}
}
