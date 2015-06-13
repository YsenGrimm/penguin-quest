﻿using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (this.transform.localPosition.x < -15.0f) { //means out of camera vision from left
			//destroy self
			Destroy(this.gameObject);
		}
		else if (this.transform.localPosition.y < -7.5f) { //means out of camera vision downward
			//destroy self
			Destroy(this.gameObject);
		}
	
	}
}
