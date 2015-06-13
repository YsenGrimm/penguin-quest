﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum PlayerStates{
		k_unknown=-1,
		k_idle,
		k_jump,
		k_sliding,

	};
	// Use this for initialization;
	public PlayerStates playerState = PlayerStates.k_unknown;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	public float propsSpeed=3.0f;

	void Start () {
		playerState= PlayerStates.k_idle;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				// only then move the start point pillar to left
				if(startPoint!=null)
					startPoint.GetComponent<MoveProps>().enabled=true;

				penguin.velocity=Vector2.zero;
				penguin.AddForce(new Vector2(0,250));

				}
//			else if(playerState== PlayerStates.k_sliding){
//					penguin.velocity=new Vector2(3, 0);
//				}
//		}
	}

	void changeState(){
		playerState= PlayerStates.k_idle;
	}

}
