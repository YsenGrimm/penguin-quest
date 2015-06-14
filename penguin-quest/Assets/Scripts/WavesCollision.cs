using UnityEngine;
using System.Collections;

public class WavesCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col){
		if (this.gameObject.tag == "Finish" && col.gameObject.tag == "Player" && col.gameObject.transform.localPosition.y <-3.5f) {
				Debug.Log("touched waves");
				RestartGamePlay ();
		}
	}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
