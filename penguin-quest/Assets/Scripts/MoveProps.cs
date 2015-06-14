using UnityEngine;
using System.Collections;

public class MoveProps : MonoBehaviour {

	Vector2 velocity = Vector2.zero;
	public float xSpeed;
	public bool hasInitialObjects=false;
	// Use this for initialization

	void Awake(){
		hasInitialObjects=false;
	}

	void Start(){
		if (hasInitialObjects == false)
			xSpeed = Random.Range (-5.0f, -6.0f);
		else
			xSpeed = -3.0f;
		AnimateTowardsLeft (xSpeed);
	}

	public void AnimateTowardsLeft (float speed) {
		velocity = new Vector2(speed, 0);
		GetComponent<Rigidbody2D>().velocity=velocity;
	}

	public void stopVelocity(){
		GetComponent<Rigidbody2D>().velocity=Vector2.zero;
		GetComponent<Rigidbody2D>().angularVelocity=0f;

	}

}
