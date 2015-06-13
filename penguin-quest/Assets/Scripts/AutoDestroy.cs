using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public PlayerController playerCtrl;
	public RandomObjectsGenerator randomObjCtrl;
	void Awake(){
		playerCtrl = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
		randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
	}

	// Update is called once per frame
	void Update () {

		if (this.transform.localPosition.x < -15.0f) { //means out of camera vision from left

			if(this.gameObject.transform.parent !=null && this.gameObject.transform.parent.name == "InitialObjects")
				playerCtrl.removeObjFromList(this.gameObject);
			else
				randomObjCtrl.removeObjFromList(this.gameObject);
			//destroy self
			Destroy(this.gameObject);
		}
		else if (this.transform.localPosition.y < -7.5f) { //means out of camera vision downward

			if(this.gameObject.transform.parent !=null && this.gameObject.transform.parent.name == "InitialObjects")
				playerCtrl.removeObjFromList(this.gameObject);
			else
				randomObjCtrl.removeObjFromList(this.gameObject);
			//destroy self
			Destroy(this.gameObject);
		}
	
	}
}
