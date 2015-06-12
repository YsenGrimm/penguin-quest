using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
		}
	}
}
