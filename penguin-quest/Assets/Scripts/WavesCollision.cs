using UnityEngine;
using System.Collections;

public class WavesCollision : MonoBehaviour {

	bool hasPlayedSfx=false;
	// Use this for initialization
	void Start () {
		hasPlayedSfx=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col){
		if (this.gameObject.tag == "Finish" && col.gameObject.tag == "Player" && col.gameObject.transform.localPosition.y <-3.5f) {
				Debug.Log("touched waves");

			//particle efffect of water bubbles
			if(hasPlayedSfx==false){
				SoundController soundCtrl = Camera.main.GetComponent<SoundController>();
				soundCtrl.playSoundEffect("Water");
				hasPlayedSfx=true;
			}

			GameObject waterParticles = Instantiate(Resources.Load("Prefabs/BalloonBurst")) as GameObject;
			waterParticles.transform.position = new Vector3(col.gameObject.transform.position.x, -4.5f,-4.0f);
			Destroy (waterParticles,waterParticles.GetComponent<ParticleSystem>().duration);

			//stop all  movements of props
			PlayerController playerCtrl = col.gameObject.GetComponent<PlayerController>();
			playerCtrl.disableAllMoveScripts();

			RandomObjectsGenerator randomObjCtrl = GameObject.Find("RandomGenerator").GetComponent<RandomObjectsGenerator>();
			randomObjCtrl.disableAllMoveScripts();

			Invoke("RestartGamePlay",waterParticles.GetComponent<ParticleSystem>().duration+0.5f);
		}
	}

	void RestartGamePlay(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
