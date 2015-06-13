using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Animator myAnim = this.GetComponent<Animator>();
			myAnim.enabled=false;

			//increment counter

			GameObject counterText = GameObject.Find("EggCounter");
			counterText.GetComponent<Counter>().IncrementCounterByOne();

			//fade out egg and destroy
			iTween.FadeTo(this.gameObject,0.0f,1.0f);
			//animate out the pillar in y axis downwards.

			GameObject parentPillar = this.transform.parent.gameObject;
			parentPillar.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
			iTween.MoveTo(parentPillar,new Vector3(parentPillar.transform.localPosition.x
			                                       ,parentPillar.transform.localPosition.y-5.0f,
			                                       parentPillar.transform.localPosition.z),2.0f);

		}

	}
	
}
