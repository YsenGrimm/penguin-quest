using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {
	
	//void OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col){ 
		if ((this.gameObject.tag == "Spikes" || this.gameObject.tag == "Seal") && col.gameObject.tag == "Player") { 


			//play dying sound effect
			SoundController soundCtrl = Camera.main.GetComponent<SoundController> ();
			soundCtrl.playSoundEffect ("Die");

			RandomObjectsGenerator randomObjCtrl = GameObject.Find ("RandomGenerator").GetComponent<RandomObjectsGenerator> ();
			randomObjCtrl.disableAllMoveScripts ();

			PlayerController playerCtrl = col.gameObject.GetComponent<PlayerController> ();
			playerCtrl.isDead=true;
			//stop all  movements of props
			playerCtrl.disableAllMoveScripts ();

				if (this.gameObject.tag == "Spikes") {
					//float spikeDist = this.gameObject.GetComponent<PolygonCollider2D>().bounds.extents.y/3;
					//if(Vector2.Distance(this.gameObject.transform.position, col.transform.parent.position) <= spikeDist){
						//player dying animation
						playerCtrl.playdieAnimation(this.gameObject.transform.position);
						//}
					}
			else
					//stop velocity and rotation of player
					playerCtrl.stopVelocityAndRot ();
		
				//Debug.Log ("touched seal");
				Invoke ("RestartGamePlay", 1.0f);
			}
		}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
