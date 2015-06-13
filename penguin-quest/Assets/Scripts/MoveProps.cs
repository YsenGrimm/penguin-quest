using UnityEngine;
using System.Collections;

public class MoveProps : MonoBehaviour {

	Vector2 velocity = Vector2.zero;
	float xSpeed;
	// Use this for initialization
	
	void Start () {
		if (this.gameObject.tag.Equals("Orca"))
			xSpeed = -3.0f;
//		else if (this.gameObject.tag.Equals("Eggs"))
//			xSpeed = -3;
//		else if (this.gameObject.tag.Equals("Seal"))
//			xSpeed = -2;
//		else if (this.gameObject.tag.Equals("IceFloe"))
//			xSpeed = -1;
		else
			xSpeed = -2.0f;

		velocity = new Vector2(xSpeed, 0);
		GetComponent<Rigidbody2D>().velocity=velocity;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
