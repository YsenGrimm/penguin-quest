using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public Rigidbody2D penguin;
	public GameObject startPoint;
	public RandomPropsGenerator RandomPropsGenCtrl;

	void Awake () {
		RandomPropsGenCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomPropsGenerator>();
		RandomPropsGenCtrl.gen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				// only then move the start point pillar to left
				
				RandomPropsGenCtrl.gen = true;

				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
				}

				penguin.velocity=Vector2.zero;
				penguin.AddForce(new Vector2(0,250));

				}
	}
}
