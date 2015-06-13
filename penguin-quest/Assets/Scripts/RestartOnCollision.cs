using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (this.gameObject.tag == "Finish") {
			if (col.gameObject.tag == "Player" && col.gameObject.transform.localPosition.y < -4.5f) {

				// create some particle effects from water
				RestartGamePlay ();
				}
		} else if (this.gameObject.tag == "Seal" || this.gameObject.tag == "Orca") {
			if (col.gameObject.tag == "Player") {
				RestartGamePlay ();
				}
		} else if (this.gameObject.tag == "Spikes") {
			if (col.gameObject.tag == "Player") {
				//play some Sfx of penguin scream then restart
				RestartGamePlay ();
			}
		}
		else 
			RestartGamePlay ();
	}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
