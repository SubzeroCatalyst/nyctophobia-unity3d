using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
	public bool on;
	
	public void Input(){
		on = !on;
	}
}
