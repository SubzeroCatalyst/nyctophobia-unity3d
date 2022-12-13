using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController ccont;
	public GameObject interactIcon;
	public float speed = 1f;
	private float sprint = 1f;
	public float cameraOffset;
	public Transform cam;
	public float standingHeight;
	public float crouchingHeight;
	public bool crouching;
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
		
		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl) ){
			crouching = !crouching;
			if (crouching){
				cameraOffset = crouchingHeight/2;
				ccont.height = crouchingHeight;
			}else{
				cameraOffset = standingHeight/2;
				ccont.height = standingHeight;
				transform.position = transform.position + new Vector3(0,crouchingHeight/2,0);
			}
		}
		
		movement.x = Input.GetAxis("Horizontal")*speed*sprint;
		movement.z = Input.GetAxis("Vertical")*speed*sprint;		
		
		movement = transform.TransformDirection(movement);
		
		
		camerarot = new Vector3(Mathf.Clamp(camerarot.x - Input.GetAxis("Mouse Y")*xsensitivity,-90,90),camerarot.y + Input.GetAxis("Mouse X")*ysensitivity,0);
		
		cam.rotation = Quaternion.Euler(camerarot);
		
		transform.rotation = Quaternion.Euler(0,camerarot.y,0);
		
		ccont.Move(movement*Time.deltaTime);
		cam.localPosition = new Vector3(0,cameraOffset,0);
	}
	
	void FixedUpdate()
    {
        RaycastHit hit;
		interactIcon.SetActive(false);
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 1.5f)){
//			Debug.Log("hit gameobject " + hit.transform.gameObject);
			if (hit.transform.gameObject.CompareTag("interactable")){
				hit.transform.gameObject.GetComponent<ToggleSwitch>().isSelected = true;
				interactIcon.SetActive(true);
			}
		}
    }
}
