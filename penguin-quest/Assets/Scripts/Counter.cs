using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {

	public int totalEggs =0;
	public void IncrementCounterByOne(){
		totalEggs++;
		this.GetComponent<Text> ().text = totalEggs.ToString ();
	}
}
