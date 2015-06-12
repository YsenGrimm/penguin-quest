using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
