using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				// now move the start point pillar to left and start scroll
				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
					
				}

				penguin.velocity=Vector2.zero;
				penguin.AddForce(new Vector2(0,200));
			}


	}
}
