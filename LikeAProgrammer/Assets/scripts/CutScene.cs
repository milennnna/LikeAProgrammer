using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

	public int sceneDuration = 4;
	public int nextScene = 2;

	// Use this for initialization
	void Start () {
		StartCoroutine (PlayScene());
	}
	
	IEnumerator PlayScene() {
		yield return new WaitForSecondsRealtime(sceneDuration);
		SceneManager.LoadScene(nextScene);
	}
}
