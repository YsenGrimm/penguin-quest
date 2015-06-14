using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col)
	{ 
		if (this.gameObject.tag == "Seal" && col.gameObject.tag == "Player") { //|| this.gameObject.tag == "Orca" // lets not collide with orca 
				//player dying animation
				Debug.Log ("touched seal");
				RestartGamePlay ();

		} else if (this.gameObject.tag == "Spikes" && col.gameObject.tag == "Player") {
				//play some Sfx of penguin scream then restart
				Debug.Log ("touched spikes");
				RestartGamePlay ();

		}
//			else if (this.gameObject.tag == "Finish" && col.gameObject.tag == "Player" && col.gameObject.transform.localPosition.y <-3.5f) {
//				Debug.Log ("touched water");
//				RestartGamePlay ();
//			}
		}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
