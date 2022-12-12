using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
	public GameObject player;
	public Transform playerPos;
	public RandomRotation headshaker;
	public RandomSound sfx;
	public AudioClip seenSfx;
	private Collider pcollider;
	public Camera pov;
	private Plane[] fplanes;
	public Animation anim;
	public AnimationClip[] animations;
	public Transform[] waypoints;
	private UnityEngine.AI.NavMeshAgent nav;
	public float timer;
	public PlayerVariables pvars;
	bool chase;
	bool oldChase;
    // Start is called before the first frame update
    void Start()
    {
		pvars = player.gameObject.GetComponent<PlayerVariables>();
		pcollider = player.gameObject.GetComponent<Collider>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
		fplanes = GeometryUtility.CalculateFrustumPlanes(pov);
		if (GeometryUtility.TestPlanesAABB(fplanes, pcollider.bounds) || Vector3.Distance(playerPos.position,transform.position) > 1f){
			if(Physics.Linecast(pov.transform.position, playerPos.position, out RaycastHit hit)){
				if(hit.transform.gameObject == player  && pvars.inLight) { 
				chase = true;
				}
			} 
		}
		
		if (chase != oldChase && chase){
			sfx.src.PlayOneShot(seenSfx);
			oldChase = chase;
		}
		if(chase){
			Chase();
		}else{
			Wander();
		}
		
		if (nav.velocity.magnitude > 0){
			if (chase) {
			anim.Play(animations[2].name);
			}else{
			anim.Play(animations[0].name);
			}
		} else {
			anim.Play(animations[1].name);
		}
    }
	
	void Chase(){
		headshaker.intensity = 30f;
		sfx.enabled = false;
		if(transform.position == playerPos.position){
			chase = false;
			oldChase = false;
		}
		nav.speed = 5f;
		nav.SetDestination(playerPos.position);
	}
	
	void Wander(){
		headshaker.intensity = 5f;
		sfx.enabled = true;
		nav.speed = 1.5f;
		if (nav.velocity.magnitude <= 0){
			
			if (timer < 0f){
				nav.SetDestination(waypoints[Random.Range(0,waypoints.Length)].position);
				timer = Random.Range(4f,6f);
			} else {
			timer -= Time.deltaTime;
			}
		}

	}
}
