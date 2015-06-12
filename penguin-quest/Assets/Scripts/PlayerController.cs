using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum PlayerStates{
		k_unknown=-1,
		k_idle,
		k_jumpingOffPillar,
		k_jumpingOnGround,
		k_grounded,
		k_sliding,

	};
	// Use this for initialization;
	public PlayerStates playerState = PlayerStates.k_unknown;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space"))// && playerState== PlayerStates.k_unknown)
		{
			// only then move the start point pillar to left
			if(startPoint!=null)
				startPoint.GetComponent<MoveProps>().enabled=true;

			//playerState= PlayerStates.k_jumpingOffPillar;

			penguin.velocity=Vector2.zero;
			penguin.AddForce(new Vector2(0,250));
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			penguin.velocity=new Vector2(3, 0);
		}

	}

}
