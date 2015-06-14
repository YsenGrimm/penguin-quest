using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjectsGenerator : MonoBehaviour {

	public bool objectOnlastGenPos=false;
	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	public GameObject lastGeneratedObject;
	public Vector2 lastGeneratedObjPos;
	//ArrayList indexArray 				= new ArrayList();
	List<GameObject> generatedObjList = new List<GameObject>();
	int index,lastIndex= 0;
	float xContentSize=5.0f;
	bool isFirstTime=false;
	// Use this for initialization

	public void randomSelectionIndex(){	

		CancelInvoke("randomSelectionIndex");

		if (isFirstTime == false) {
			index = 2;
			isFirstTime = true;
		} else {
			index = Random.Range (0, 6);
			// check if the last generated index is not picked again
			if (index == lastIndex) {
				while (index==lastIndex) {
					index = Random.Range (0, 6);
				}
			}
		}
//		int counter=0;
//		index  = Random.Range(0,6);
//		while(listContainsString(indexArray,index.ToString()) && counter<30){
//			index = Random.Range(0,6);
//			counter++;
//		}
//		indexArray.Add(index.ToString());
		objectOnlastGenPos=false;
		Debug.Log ("generate objects now");
		Invoke("GenerateObjectsRandomly",0.5f);
	}


	bool listContainsString(ArrayList array, string name){
		
		foreach(string str in array){
			if(str.Equals(name))
				return true;
		}
		return false;
	}

	void GenerateObjectsRandomly(){

		float xPos = 7.5f + xContentSize;
		switch (index) {

		case 0:{
			int rand = Random.Range (0, 2);
			string fileName = "";
			if (rand == 0)
				fileName = "SealOnIce";
			else
				fileName = "SealOnIceAnim";

			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/"+fileName) as GameObject,new Vector3(xPos,
                                                                           Random.Range(-4.5f, -4.65f),0),
                                                                      Quaternion.identity) as GameObject;

			objectOnlastGenPos=true;

		}break;
		case 1:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(xPos,
                                                                                    Random.Range(-4.0f,-4.5f),0),
                                                             						 Quaternion.identity) as GameObject;
			objectOnlastGenPos = true;
		}break;
		case 2:{
			int rand = Random.Range (0, 2);
			string icefloeName = "";
			if (rand == 0)
				icefloeName = "IceFloe_Small";
			else
				icefloeName = "IceFloe_Large";

			lastGeneratedObject = Instantiate (Resources.Load ("Prefabs/" + icefloeName) as GameObject, new Vector3 (xPos,
	                                                                                   Random.Range (-4.25f, -4.65f),
	                                                                                    0),Quaternion.identity)  as GameObject;
			objectOnlastGenPos=true;

		}break;
		case 3:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/Orca") as GameObject,new Vector3(xPos,Random.Range(-4.5f,-5.0f),0),
	                                  																Quaternion.identity) as GameObject;
			objectOnlastGenPos=true;
		}break;

		case 4:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/IceSpikes") as GameObject,new Vector3(xPos,
                                                                                    Random.Range(-3.5f, -4.0f),0),
																                      Quaternion.identity) as GameObject;
			
			objectOnlastGenPos=true;
			
		}break;

		case 5:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/Iceberg") as GameObject,new Vector3(xPos,
                                                                                    Random.Range(-3.5f, -4.25f),0),
												                                  Quaternion.identity) as GameObject;
			
			objectOnlastGenPos=true;
			
		}break;
		
		default: 
			objectOnlastGenPos=false; break;
		}

		if (lastGeneratedObject != null)
			xContentSize = lastGeneratedObject.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x*2;
		lastIndex = index;
		generatedObjList.Add(lastGeneratedObject);
		CancelInvoke ("GenerateObjectsRandomly");
		Invoke("randomSelectionIndex",1.0f);

	}

	public void removeObjFromList(GameObject obj){
		if (generatedObjList.Count > 0) {
			generatedObjList.Remove(obj);
		}
	}

	public void disableAllMoveScripts(){
		if (generatedObjList.Count > 0) {
			for (int i=0; i<generatedObjList.Count; i++) {
				MoveProps script = (MoveProps)generatedObjList [i].GetComponent<MoveProps> ();
				script.stopVelocity();
				//script.enabled = false;
			}
		}
	}

//	public void increaseSpeedOverTime(){
//		if (generatedObjList.Count > 0) {
//			for (int i=0; i<generatedObjList.Count; i++) {
//				MoveProps script = (MoveProps)generatedObjList [i].GetComponent<MoveProps> ();
//				script.incrementSpeedOverTime();
//			}
//		}
//	}



}
