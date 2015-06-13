using UnityEngine;
using System.Collections;

public class MoveProps : MonoBehaviour {

	Vector2 velocity = Vector2.zero;
	float xSpeed;
	// Use this for initialization
	
	void Start () {
		if (this.gameObject.tag.Equals("Orca"))
			xSpeed = -6.0f;
		else
			xSpeed = Random.Range(-3.0f,-5.0f);

		velocity = new Vector2(xSpeed, 0);
		GetComponent<Rigidbody2D>().velocity=velocity;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
