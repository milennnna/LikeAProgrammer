﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

	class Enemy : GameObject {

		public EnemyType type;
		public Rigidbody2D rigidBody;
	}

	enum EnemyType {

		Battery = 0,
		Character,
		Integer,
		NumberOfTypes
	}

	class ScheduledSpawn {

		public float velocity;
		public float spin;
		public EnemyType type;
		public int spawnTime;
	}

	public int distanceStepsAtLowestSpeed = 60; // distance between shield and spawning circle (must be dividable by 6!!!)

	public float timeStepDuration = 0.5f; // minimal time between two arrivals
	public float baseVelocity = 10.0f; // slowest enemy velocity

	private float distance = distanceStepsAtLowestSpeed * timeStepDuration * baseVelocity; // unity distance

	public int maxScheduledInterval = 10; // max steps in future for scheduling

	public float maxSpin;

	public GameObject laikaReference;
	public Enemy batteryReference;
	public Enemy characterReference;
	public Enemy integerReference;

	private List<Enemy> reusableEnemyPool = new List<Enemy>();

	private List<int> scheduledArrivalTimes;
	private List<ScheduledSpawn> scheduledSpawns;
	private int currentTime = 0;

	private Dictionary<EnemyType, float> speedMultipliers = new Dictionary<EnemyType, float>() {

		{ EnemyType.Battery, 1.0f },
		{ EnemyType.Character, 2.0f },
		{ EnemyType.Integer, 3.0f }
	};
		
	// Use this for initialization
	void Start () {

		StartCoroutine (callStepRoutines());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator callStepRoutines() {

		yield return new WaitForSeconds(timeStepDuration);
		currentTime++;
		scheduleSpawn ();
		spawnEnemies ();
	}

	// Schedules an enemy spawn
	void scheduleSpawn() {

		int scheduleTime = currentTime + Random (1, maxScheduledInterval);
		EnemyType type = new EnemyType (Random (0, EnemyType.NumberOfTypes - 1)); // TODO weighted probabilities
		while (scheduledArrivalTimes.Contains(arrivalTime(speedMultipliers[type], scheduleTime))) {

			scheduleTime++;
		}
		ScheduledSpawn spawn = new ScheduledSpawn ();
		spawn.spawnTime = scheduleTime;
		spawn.velocity = speedMultipliers[type] * baseVelocity;
		spawn.spin = 0.0f; // TODO
		spawn.type = type;
		scheduledSpawns.Add (spawn);
	}

	// Determines arrival time of an enemy
	int arrivalTime(int speedMultiplier, int spawnTime) { 

		return spawnTime + distanceStepsAtLowestSpeed / speedMultiplier;
	}

	// Spawns all enemies scheduled for current time
	void spawnEnemies() {
		foreach (ScheduledSpawn spawn in scheduledSpawns.GetEnumerator) {

			if (spawn.spawnTime == currentTime) {

				spawnEnemy (spawn);
				scheduledSpawns.Remove (spawn);
			}
		}
	}

	// Spawns an enemy
	void spawnEnemy(ScheduledSpawn spawn) {

		// check if there is free instance in pool
		Enemy newEnemy;
		foreach (Enemy enemy in reusableEnemyPool) {

			if (!enemy.activeInHierarchy && enemy.type == spawn.type) {

				newEnemy = enemy;
			}
		}
		// create new if needed
		if (newEnemy == null) {

			switch (spawn.type) {
			case EnemyType.Battery: 
				newEnemy = Instantiate<Enemy> (batteryReference);
				break;
			case EnemyType.Character: 
				newEnemy = Instantiate<Enemy> (characterReference);
				break;
			case EnemyType.Integer: 
				newEnemy = Instantiate<Enemy> (integerReference);
				break;
			default:
				break;
			}
			reusableEnemyPool.Add (newEnemy);
		}
		// populate
		Vector2 center = laikaReference.transform.position;
		float angle = Random (0, 2 * Mathf.PI);
		Vector2 startPoint = distance * new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
		Vector2 direction = center - startPoint;
		newEnemy.transform.position = startPoint;
		newEnemy.rigidBody.velocity = direction * baseVelocity * speedMultipliers [spawn.type];
		// add to scene
		newEnemy.SetActive(true);
	}
}
