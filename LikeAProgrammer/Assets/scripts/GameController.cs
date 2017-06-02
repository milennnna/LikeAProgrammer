using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public bool playing;
	public float timeLeft;

	// Use this for initialization
	void Start () {
		playing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (playing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			//TODO:
			//Add reference to text component and display proper timeLeft
			//UpdateText();
		}
	}
}
