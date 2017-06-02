using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public bool playing = true;
	public float timeLeft = 5;
	private int time=5;

	public Text timeLeftText;

	// Use this for initialization
	void Start () {
		playing = true;
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
			UpdateTimer();
		}
	}

	private void UpdateTimer() {
		timeLeftText.text = Mathf.Round(timeLeft).ToString ();
	}

}
