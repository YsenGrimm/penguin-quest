using UnityEngine;
using System.Collections;

public class IceFloeController : MonoBehaviour {


	GameObject playerObj;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			PlayerController playerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerController> ();
			playerCtrl.stopVelocityAndRot();


			//play icefloe wiggle animation
			if(this.gameObject.tag=="IceFloe")
				iTween.ShakeRotation(this.gameObject,new Vector3(0,0,5f),0.5f);
			}

	}
}
