using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudGenerator : MonoBehaviour {
	
	public List<GameObject> clouds = new List<GameObject>(); 
	GameObject selectedCloud;
	int randomIndex;
	Vector3 startPos = new Vector3(10.0f,4.0f,0.0f);
	Vector3 endPos = new Vector3(-15.0f,4.0f,0.0f);
	// Use this for initialization
	
	void destroyCloud(Object obj){
		Destroy((GameObject)obj);
	}
	void createClouds(){
		randomIndex = Random.Range(0,clouds.Count);
		selectedCloud = Instantiate(clouds[randomIndex],startPos,Quaternion.identity) as GameObject;
		iTween.MoveTo(selectedCloud,iTween.Hash("position",endPos,"time",30.0f,"onComplete","destroyCloud",
		                                        "oncompletetarget", gameObject,"oncompleteparams",selectedCloud,"easetype",iTween.EaseType.linear));
		Invoke("createClouds",20.0f);
	}
	void Start (){
		createClouds();
		
	}
}