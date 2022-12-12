using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	public float intensity;
	public bool x = true;
	public bool y = true;
	public bool z = true;
	public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float xr;
		float yr;
		float zr;
		if (x) {xr = 1;} else {xr = 0;}
		if (y) {yr = 1;} else {yr = 0;}
		if (z) {zr = 1;} else {zr = 0;}
		intensity = Mathf.Clamp(intensity,0,360);
        Vector3 rot = new Vector3(Random.Range(-intensity,intensity)*xr,Random.Range(-intensity,intensity)*yr,Random.Range(-intensity,intensity)*zr);
		rot = rot + offset;
		transform.localRotation = Quaternion.Euler(rot);
    }
}
