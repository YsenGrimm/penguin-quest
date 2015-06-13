using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {

	int counter =0;
	public void IncrementCounterByOne(){
		counter++;
		this.GetComponent<Text> ().text = counter.ToString ();
	}
}
