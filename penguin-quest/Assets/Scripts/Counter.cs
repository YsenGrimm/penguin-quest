using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {

	int counter =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementCounterByOne(){
		counter++;
		this.GetComponent<Text> ().text = counter.ToString ();
	}
}
