using UnityEngine;
using System.Collections;

public class SOA_ChangeSortingLayer : MonoBehaviour {


	public string sortingLayerName;
	// Use this for initialization
	void Awake () {

		SpriteRenderer myRenderer =  this.gameObject.GetComponent<SpriteRenderer>();
		if(myRenderer != null)
			myRenderer.sortingLayerName = sortingLayerName;
	
	}
}
