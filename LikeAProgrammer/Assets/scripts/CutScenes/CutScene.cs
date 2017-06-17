using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

	public int sceneDuration = 4;
	public int nextScene = 2;

	public Image black;
	public Animator anim;

	// Use this for initialization
	void Start () {
		StartCoroutine (PlayScene());
	}
	
	IEnumerator PlayScene() {
		yield return new WaitForSecondsRealtime(sceneDuration);
		anim.SetBool ("Fade", true);
		yield return new WaitUntil(()=>black.color.a==1);
		SceneManager.LoadScene(nextScene);
	}
}
