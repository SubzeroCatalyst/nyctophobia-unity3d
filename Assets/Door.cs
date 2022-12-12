using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public Reciever recv;
	public Vector3 moveTo;
	public float speed;
	Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
		moveTo = moveTo + currentPos;
    }

    // Update is called once per frame
    void Update()
    {
		
        if (recv.on){
			transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);
		}else{
			transform.position = Vector3.MoveTowards(transform.position, currentPos, speed);
		}
	
	}
}
