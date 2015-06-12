using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D penguin;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space"))
		{
			penguin.velocity=Vector2.zero;
			penguin.AddForce(new Vector2(0,250));
		}

	}


}
