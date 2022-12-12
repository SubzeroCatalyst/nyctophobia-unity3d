using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : CollisionTrigger
{
	public AudioClip sfx;
	public AudioSource src;
	public Reciever reciever;
	public float resetDelay;
	public float timer;
	
	private void FixedUpdate(){
		timer -= Time.deltaTime;
	}
	
	public override void FakeOnTriggerStay(){
		
		if(Input.GetKeyDown(KeyCode.E)){
			if(timer < 0f){
				src.PlayOneShot(sfx);
				if(reciever){
				reciever.Input();
				}
				timer = resetDelay;
			}
		}
	}
}
