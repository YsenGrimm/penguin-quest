using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col)
	{ 
		if (this.gameObject.tag == "Seal" ) { //|| this.gameObject.tag == "Orca" // lets not collide with orca 
			if (col.gameObject.tag == "Player") {
				//player dying animation
				Debug.Log("touched seal or orca");
				RestartGamePlay ();
				}
		} else if (this.gameObject.tag == "Spikes") {
			if (col.gameObject.tag == "Player") {
				//play some Sfx of penguin scream then restart
				Debug.Log("touched spikes");
				RestartGamePlay ();
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (this.gameObject.tag == "Waves") {
			if (col.gameObject.tag == "Player")
				Debug.Log("touched waves");
				RestartGamePlay ();
			}
		}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
