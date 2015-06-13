using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public GameObject timerObj;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	public List<GameObject> initialObjList = new List<GameObject>(); // no movement until you press space

	bool randomFunc = false;
	bool isfirstJump = false;
	bool hasAngleSet = false;
	public float jumpForce=100f;
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				hasAngleSet=false;
				// now move the start point pillar to left and start scroll
				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
					}

				//set the timer 
				 timerObj.GetComponent<CountDownTimer>().enabled=true;

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

			if(isfirstJump==false){
				 this.gameObject.GetComponent<Animator>().enabled=true;
				}
			else{
			
//				Vector2 velocityDir = penguin.velocity;
//				if (velocityDir.y < 0)
//					penguin.MoveRotation (-20.0f);
//				else if (velocityDir.y > 0)
//					penguin.MoveRotation (20.0f);

				penguin.MoveRotation (20.0f); //face up
				penguin.velocity=Vector2.zero;
				penguin.angularVelocity = 0f;
				penguin.AddForce(new Vector2(0,jumpForce));
				if(hasAngleSet==false)
					Invoke("setAngleDown",0.5f);
			}
		}

	}

	void setAngleDown(){
		penguin.MoveRotation (-20.0f);
		hasAngleSet = true;
	}
	void setBackAngleToZero(){
		penguin.MoveRotation (0);
		hasAngleSet = true;
	}

	public void removeObjFromList(GameObject obj){
		if (initialObjList.Count > 0) {
			initialObjList.Remove (obj);
		}
	}

	public void changeTextureToSlide(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Art/penguin_sliding", typeof(Sprite)) as Sprite;
		BoxCollider2D playerCol = this.gameObject.GetComponent<BoxCollider2D>();
		playerCol.size = new Vector2(3.5f,1.803128f);
		playerCol.offset = new Vector2(0f,-0.02656f);

		//update position of player's parent, get world position

		Vector3 worldPos = transform.TransformPoint(this.gameObject.transform.localPosition);
		this.transform.parent.transform.position= new Vector3(worldPos.x,worldPos.y+1.0f,worldPos.z); 
		this.gameObject.GetComponent<Animator>().enabled=false;

		isfirstJump = true;
	}


}
