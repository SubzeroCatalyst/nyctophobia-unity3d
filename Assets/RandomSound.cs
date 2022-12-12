using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
	public AudioClip[] clips;
    
	public AudioSource src;
	
	public float minimumTime = 5f;
	public float maximumTime = 8f;
	private float timer;
	// Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {		
		if (timer < 0){
			src.PlayOneShot(clips[Random.Range(0,clips.Length)]);
			timer = Random.Range(minimumTime,maximumTime);
		} else {
			timer -= Time.deltaTime;
		}
    }
}
