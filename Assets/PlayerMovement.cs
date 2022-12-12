using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController ccont;
	public float speed = 1f;
	private float sprint = 1f;
	public Transform cam;
	public float xsensitivity;
	public float ysensitivity;
	Vector3 camerarot;
	Vector3 movement;
	public float rollOffset;
	PlayerVariables pvars;
    // Start is called before the first frame update
    void Start()
    {
		pvars = GetComponent<PlayerVariables>();
        ccont = GetComponent<CharacterController>();
		movement.y = -3f;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetAxis("Run")>0f){
			sprint = 1.5f;
		}else{
			sprint = 1f;
		}
		
		movement.x = Input.GetAxis("Horizontal")*speed*sprint;
		movement.z = Input.GetAxis("Vertical")*speed*sprint;		
		
		movement = transform.TransformDirection(movement);
		
		camerarot = new Vector3(Mathf.Clamp(camerarot.x - Input.GetAxis("Mouse Y")*xsensitivity,-90,90),camerarot.y + Input.GetAxis("Mouse X")*ysensitivity,0);
		
		cam.rotation = Quaternion.Euler(camerarot);
		
		transform.rotation = Quaternion.Euler(0,camerarot.y,0);
		
		ccont.Move(movement*Time.deltaTime);
    }
}
