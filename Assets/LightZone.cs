using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class LightZone : MonoBehaviour
{
	
	private void OnTriggerStay(Collider collider){
		if(!collider.CompareTag("Player")) return;
        collider.gameObject.GetComponent<PlayerVariables>().inLight=true;
	}

    private void OnTriggerExit(Collider collider)
    {
        if(!collider.CompareTag("Player")) return;
        collider.gameObject.GetComponent<PlayerVariables>().inLight=false;
    }
	
}
