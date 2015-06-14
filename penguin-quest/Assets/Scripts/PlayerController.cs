using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public GameObject timerObj;
	public GameObject eggCounterObj;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	public List<GameObject> initialObjList = new List<GameObject>(); // no movement until you press space

	bool randomFunc = false;
	bool isfirstJump = false;
	bool hasAngleSet = false;
	public float jumpForce=100f;
	public bool isDead = false;

	void UpdateTheGameStats(){

		//check for the last score
		float lastTime 		= PlayerPrefs.GetFloat ("Time");
		int lastEggScore 	= PlayerPrefs.GetInt ("Eggs");

		//get time from timerObj
		float timeElapsed = timerObj.GetComponent<CountDownTimer>().time;
		int   totalEggs   = eggCounterObj.GetComponent<Counter>().totalEggs;

		if ((lastTime < timeElapsed) && (lastEggScore > totalEggs)) {
			PlayerPrefs.SetFloat ("Time", timeElapsed);
			PlayerPrefs.SetInt ("Eggs", totalEggs);
			}
		//to display on highscore use this

		/*int minutes = (int)time / 60;
		int seconds = (int)time % 60;
		//displaying in the timer text
		this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);*/

	}

	// Update is called once per frame
	void Update () {
	
		if (isDead == true) {
			UpdateTheGameStats();
			return;
			}
			

		if(Input.GetKeyUp("space")){
				hasAngleSet=false;
				// now move the start point pillar to left and start scroll
				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
					startPoint.GetComponent<MoveProps>().hasInitialObjects=true;
					}

				//set the timer 
				 timerObj.GetComponent<CountDownTimer>().enabled=true;
				if(initialObjList.Count>0){
						for(int i =0;i<initialObjList.Count;i++){
							GameObject obj = (GameObject)initialObjList[i];
							obj.GetComponent<MoveProps>().enabled=true;
							obj.GetComponent<MoveProps>().hasInitialObjects=true;
						}
				}


			if(isfirstJump==false){

				SoundController soundCtrl = Camera.main.GetComponent<SoundController>();
				soundCtrl.playSoundEffect("Jump1");

				this.gameObject.GetComponent<Animator>().enabled=true;
				this.gameObject.GetComponent<Animator>().speed=0.8f;
				}
			else{

				SoundController soundCtrl = Camera.main.GetComponent<SoundController>();
				soundCtrl.playSoundEffect("Jump2");

				penguin.MoveRotation (20.0f); //face up
				penguin.velocity=Vector2.zero;
				penguin.angularVelocity = 0f;
				penguin.AddForce(new Vector2(0,jumpForce));
				if(hasAngleSet==false)
					Invoke("setAngleDown",0.5f);
			}




		}

		if(randomFunc==false && initialObjList.Count<=3){
			Debug.Log("enable random");
			// now generate random objects
			RandomObjectsGenerator randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
			randomObjCtrl.enabled=true;
			randomObjCtrl.randomSelectionIndex();
			randomFunc=true;
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


	public void disableAllMoveScripts(){
		if (initialObjList.Count > 0) {
			for (int i=0; i<initialObjList.Count; i++) {
				MoveProps script = (MoveProps)initialObjList [i].GetComponent<MoveProps> ();
				script.stopVelocity();
				//script.enabled = false;
			}
		}
	}

	public void stopVelocityAndRot(){
		penguin.MoveRotation (0);
		penguin.velocity = Vector2.zero;
		penguin.angularVelocity = 0f;
	}

	public void playdieAnimation(Vector3 pos){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Art/penguin_sliding_dead", typeof(Sprite)) as Sprite;
		penguin.isKinematic = true;
		}

	public void changeTextureToSlide(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Art/penguin_sliding_sledge", typeof(Sprite)) as Sprite;
		PolygonCollider2D playerCol = this.gameObject.GetComponent<PolygonCollider2D>();
		DestroyObject(playerCol);

		this.gameObject.AddComponent<PolygonCollider2D>();
		//update position of player's parent, get world position

		Vector3 worldPos = transform.TransformPoint(this.gameObject.transform.localPosition);
		this.transform.parent.transform.position= new Vector3(worldPos.x,worldPos.y+1.75f,worldPos.z); //hack
		this.gameObject.GetComponent<Animator>().enabled=false;

		isfirstJump = true;
	}


}
