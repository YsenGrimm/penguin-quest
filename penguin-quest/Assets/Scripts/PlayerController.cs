using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization;
	public Rigidbody2D penguin;
	public GameObject startPoint;

	public List<GameObject> initialObjList = new List<GameObject>(); // no movement until you press space

	bool randomFunc = false;
	bool isfirstJump = false;
	public float jumpForce=100f;
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp("space")){
				// now move the start point pillar to left and start scroll
				if(startPoint!=null){
					startPoint.GetComponent<MoveProps>().enabled=true;
					}

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
				penguin.velocity=Vector2.zero;
				penguin.AddForce(new Vector2(0,jumpForce));
				}
		}
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
