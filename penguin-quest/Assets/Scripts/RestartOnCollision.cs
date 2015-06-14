using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {
	
	//void OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col)
	{ 
		if ((this.gameObject.tag == "Seal" || this.gameObject.tag == "Spikes")&& col.gameObject.tag == "Player") { 

			//|| this.gameObject.tag == "Orca" // lets not collide with orca 

				//player dying animation
				SoundController soundCtrl = Camera.main.GetComponent<SoundController>();
				soundCtrl.playSoundEffect("Die");

			//stop all  movements of props
				PlayerController playerCtrl = col.gameObject.GetComponent<PlayerController>();
				playerCtrl.disableAllMoveScripts();
			
				RandomObjectsGenerator randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
				randomObjCtrl.disableAllMoveScripts();

				//Debug.Log ("touched seal");
				Invoke("RestartGamePlay",0.75f);
			}
		}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
