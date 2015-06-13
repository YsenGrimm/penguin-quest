using UnityEngine;
using System.Collections;

public class IceFloeController : MonoBehaviour {


	GameObject playerObj;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			//play icefloe wiggle animation
			iTween.ShakeRotation(this.gameObject,new Vector3(0,0,5f),0.5f);

			}

	}
}
