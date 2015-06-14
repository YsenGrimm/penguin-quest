using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	
	public GameObject HowToOverlay;
	public GameObject AboutOverlay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayGame () {
		PlayerPrefs.SetInt ("NumOfTries", 1);
		Application.LoadLevel("GamePlay_Level1");
	}
	
	public void DisplayHowTo() {
		HowToOverlay.SetActive(true);
	}
	
	public void DisplayAbout() {
		AboutOverlay.SetActive(true);
	}
	
	public void HideHowTo() {
		HowToOverlay.SetActive(false);
	}
	
	public void HideAbout() {
		AboutOverlay.SetActive(false);
	}
	
	public void QuitGame() {
		Application.Quit();
	}
	
	public void SwitchToHighscore() {
		Application.LoadLevel("Highscore");
	}
}
