using UnityEngine;
using System.Collections;

public class IceFloeController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {

			GameObject player = col.gameObject;
			//change player state to sliding

			iTween.RotateTo(player,new Vector3(0,-45f,0),1.0f);
			iTween.FadeTo(player,0.0f,1.0f);
			//change texture of player to sliding and enable 2nd box collider
			player.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Art/penguin_sliding", typeof(Sprite)) as Sprite;
			iTween.FadeTo(player,1.0f,0.5f);
			iTween.RotateTo(player,new Vector3(0,0,0),0.5f);

			BoxCollider2D playerCol = player.GetComponent<BoxCollider2D>();
			playerCol.size = new Vector2(3.5f,1.803128f);
			playerCol.offset = new Vector2(0f,-0.02656f);
			}

	}
}
