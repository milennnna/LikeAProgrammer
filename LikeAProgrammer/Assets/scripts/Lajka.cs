using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lajka : MonoBehaviour {

	//public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy(other.gameObject);
		Debug.Log ("Test");
	}

	void UpdateScore() {
		// If battery
		// full/empty
		// check pattern
		// setScore
		//scoreText.text = "";
	}

	//void UpdateText() {
	//	timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
	//
}
