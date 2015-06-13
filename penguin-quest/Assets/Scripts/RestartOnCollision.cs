using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (this.gameObject.name == "Background") {
			if (col.gameObject.tag == "Player" && col.gameObject.transform.localPosition.y < -3.75f) {

				// create some particle effects from water

				//then restart game after particles have finished

				Application.LoadLevel (Application.loadedLevel); //restart game
			}
		}

		else if(this.gameObject.tag == "Seal" || this.gameObject.tag == "Orca") {
			if (col.gameObject.tag == "Player") {

				//play some Sfx of penguin scream then restart

				Application.LoadLevel (Application.loadedLevel); //restart game
			}
		}
		else
			Application.LoadLevel(Application.loadedLevel);
	}
}
