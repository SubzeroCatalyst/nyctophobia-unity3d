using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
	public AudioClip sfx;
	public AudioSource src;
	public Reciever reciever;
	public float resetDelay;
	public float timer;
	public bool isWorking = true;
	public bool isSelected;
	
	private void FixedUpdate(){
		timer -= Time.deltaTime;
		if(isSelected){
		if(Input.GetKeyDown(KeyCode.E)){
			if(timer < 0f){
				src.PlayOneShot(sfx);
				if(reciever && isWorking){
				reciever.Input();
				}
				timer = resetDelay;
			}
		}
		isSelected = false;
		}
	}
}
