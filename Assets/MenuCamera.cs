using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
	float pcurtime;
	float ycurtime;
	public float pitchMagnitude;
	public float yawMagnitude;
	public float pitchSpeed;
	public float yawSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		pcurtime = pcurtime + Time.deltaTime * pitchSpeed;
		ycurtime = ycurtime + Time.deltaTime * yawSpeed;
		Vector3 rot = new Vector3(Mathf.Sin(pcurtime)*pitchMagnitude,Mathf.Sin(ycurtime)*yawMagnitude,0);
        transform.rotation = Quaternion.Euler(rot);
    }
}
