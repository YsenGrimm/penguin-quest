using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjectsGenerator : MonoBehaviour {

	public bool objectOnlastGenPos=false;
	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	public GameObject lastGeneratedObject;
	public Vector2 lastGeneratedObjPos;

	List<GameObject> generatedObjList = new List<GameObject>();

	int index = 0;
	// Use this for initialization

	public void randomSelectionIndex(){	

		CancelInvoke("randomSelectionIndex");
		index  = Random.Range(0,4);
		objectOnlastGenPos=false;
		Invoke("GenerateObjectsRandomly",0.5f);
	}


	void GenerateObjectsRandomly(){

		switch (index) {

		case 0:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/SealOnIce") as GameObject,new Vector3(15.0f,
			                                                                           Random.Range(-4.5f, -5.5f),0),
			                                                                      Quaternion.identity) as GameObject;

			objectOnlastGenPos=true;

		}break;
		case 1:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(10.0f,
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

			lastGeneratedObject = Instantiate (Resources.Load ("Prefabs/" + icefloeName) as GameObject, new Vector3 (15.0f,
			                                                                                   Random.Range (-4.25f, -4.75f),
			                                                                                    0),Quaternion.identity)  as GameObject;
			objectOnlastGenPos=true;

		}break;
		case 3:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/Orca") as GameObject,new Vector3(10.0f,Random.Range(-4.5f,-5.0f),0),
			                                  																Quaternion.identity) as GameObject;
			objectOnlastGenPos=true;
		}break;

		default: 
			objectOnlastGenPos=false; break;
		}

		generatedObjList.Add(lastGeneratedObject);
		CancelInvoke ("GenerateObjectsRandomly");
		Invoke("randomSelectionIndex",3.0f);

	}

	public void removeObjFromList(GameObject obj){
		if (generatedObjList.Count > 0) {
			generatedObjList.Remove(obj);
		}
	}


}
