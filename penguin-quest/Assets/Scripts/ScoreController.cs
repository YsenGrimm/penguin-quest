using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayAgain() {
		Application.LoadLevel("GamePlay_Level1");
	}
	
	public void BackToMenu() {
		Application.LoadLevel("MainMenu");
	}
}
