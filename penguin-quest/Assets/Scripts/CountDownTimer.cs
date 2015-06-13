using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour {


	float time = 30.0f;
	public bool istimeOut = false;

	// Update is called once per frame
	void Update () {

		if(istimeOut==true)
			return;

		time -= Time.deltaTime;
		if(time<=0){
			istimeOut=true;
		}
		else if (time>0){
			istimeOut=false;
			int minutes = (int)time / 60;
			int seconds = (int)time % 60;
			int fraction = (int)(time * 100) % 100;
			//displaying in the timer text
			this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction); 
		}

	}
}