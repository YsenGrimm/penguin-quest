using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.localPosition.x < -15.0f) { //means out of camera vision from left
			//destroy self
			Destroy(this.gameObject);
		}
	
	}
}
