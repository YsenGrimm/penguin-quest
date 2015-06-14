using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	
	public Text ScoreText;

	// Use this for initialization
	void Start () {
		float time 		= PlayerPrefs.GetFloat("Time");
		int eggScore 	= PlayerPrefs.GetInt("Eggs");
		int minutes = (int)time / 60;
		int seconds = (int)time % 60;
		
		ScoreText.text = "The best player survied \n" + 
							string.Format("{0:00} : {1:00}", minutes, seconds) +
							" minutes and \ncollected " + eggScore.ToString() + " Eggs";
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
