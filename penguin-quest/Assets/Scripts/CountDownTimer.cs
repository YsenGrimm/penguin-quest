using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour {
	public float time = 0.0f;
	public bool istimeOut = false;
	public int minutes, seconds, prevSeconds=0;
	//Update is called once per frame
	PlayerController playerCtrl;
	//RandomObjectsGenerator randomObjCtrl;

	void Start(){
		playerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		//randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
	}

	void Update () {

		if(playerCtrl.isDead==true)
			return;

			 time += Time.deltaTime;
			 minutes = (int)time / 60;
			 seconds = (int)time % 60;

		//increase speed over time
//		int diff = seconds - prevSeconds;
//		if (diff <= 10) {
//			randomObjCtrl.increaseSpeedOverTime ();
//		} else
//			prevSeconds = seconds;

			//int fraction = (int)(time * 100) % 100;
			//displaying in the timer text
		this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);  //:{2:00} , fraction

	}
}