using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	public GameObject bulb;
	public AudioSource src;
	public AudioClip sound;
	public PlayerVariables pvars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
			src.PlayOneShot(sound);
			bulb.SetActive(!bulb.activeSelf);
		}
		pvars.inLight = bulb.activeSelf;
    }
}
