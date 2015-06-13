using UnityEngine;
using System.Collections;

public class IceFloeController : MonoBehaviour {


	GameObject playerObj;

	void changeTextureOfPlayer(){
		if (playerObj != null) {
			playerObj.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Art/penguin_sliding", typeof(Sprite)) as Sprite;
//			iTween.FadeTo (playerObj, 1.0f, 0.25f);
//			iTween.RotateTo (playerObj, new Vector3 (0, 0, 0), 0.5f);
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {

			//playerObj = col.gameObject;
			//change player state to sliding

			//playerObj.GetComponent<Rigidbody2D>().fixedAngle=false;

			//iTween.RotateTo(playerObj,new Vector3(0,0,-80.0f),0.5f);
			//iTween.FadeTo(playerObj,0.0f,0.25f);

			//change texture of player to sliding and enable 2nd box collider
//			Invoke("changeTextureOfPlayer",0.0f);
//
//			BoxCollider2D playerCol = playerObj.GetComponent<BoxCollider2D>();
//			playerCol.size = new Vector2(3.5f,1.803128f);
//			playerCol.offset = new Vector2(0f,-0.02656f);

			//playerObj.GetComponent<Rigidbody2D>().fixedAngle=true;
			}

	}
}
