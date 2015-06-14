using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip jumpSfx1,jumpSfx2,collectSfx,waterSplash,die;
	public AudioSource aSource;
	
	public void playSoundEffect(string _name){
		
		if(_name=="Jump1")
			aSource.clip = jumpSfx1;
		if(_name=="Jump2")
			aSource.clip = jumpSfx2;
		else if(_name=="Collect")
			aSource.clip = collectSfx;
		else if(_name=="Water")
			aSource.clip = waterSplash;
		else if(_name=="Die")
			aSource.clip = die;
		
		aSource.Play();
	}

}
