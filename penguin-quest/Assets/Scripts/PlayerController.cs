using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	public List<GameObject> initialObjList = new List<GameObject>(); // no movement until you press space

	bool randomFunc = false;
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				// now move the start point pillar to left and start scroll
				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
					}

			if(initialObjList.Count>0){
					for(int i =0;i<initialObjList.Count;i++){
						GameObject obj = (GameObject)initialObjList[i];
						obj.GetComponent<MoveProps>().enabled=true;
					}
			}
			else if(randomFunc==false && initialObjList.Count<=0){
					Debug.Log("enable random");
					// now generate random objects
					RandomObjectsGenerator randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
					randomObjCtrl.enabled=true;
					randomObjCtrl.randomSelectionIndex();
					randomFunc=true;
					}
				penguin.velocity=Vector2.zero;
				penguin.AddForce(new Vector2(0,200));
			}
	}

	public void removeObjFromList(GameObject obj){
		if (initialObjList.Count > 0) {
			initialObjList.Remove (obj);
		}
	}

}
