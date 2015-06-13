using UnityEngine;
using System.Collections;

public class RandomObjectsGenerator : MonoBehaviour {

	public bool objectOnlastGenPos=false;
	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	public GameObject lastGeneratedObject;
	public Vector2 lastGeneratedObjPos;

	int index = 0;
	// Use this for initialization
	void Start(){
		randomSelectionIndex ();
		
	}

	void randomSelectionIndex(){	

		CancelInvoke("randomSelectionIndex");
		index  = Random.Range(0,3);
		objectOnlastGenPos=false;
		Invoke("GenerateObjectsRandomly",0.5f);
	}


	void GenerateObjectsRandomly(){

		switch (index) {

		case 0:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/SealOnIce") as GameObject,new Vector3(15.0f,
			                                                                           Random.Range(-2.3f, -3.3f),0),
			                                                                      Quaternion.identity) as GameObject;

			objectOnlastGenPos=true;

		}break;
		case 1:{
			lastGeneratedObject = Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(this.transform.localPosition.x,
			                                                                                                    Random.Range(-3.5f,-4.5f),0),
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
			                                                                                   Random.Range (-2.3f, -3.3f),
			                                                                                    0),Quaternion.identity)  as GameObject;
			objectOnlastGenPos=true;

		}break;
		case 3:{
			Invoke("GenerateIceFloes",5.0f);
		}break;

		default: 
			objectOnlastGenPos=false; break;
		}

		CancelInvoke ("GenerateObjectsRandomly");
		Invoke("randomSelectionIndex",3.0f);


	}

}
