using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

	public float speed;
	public bool SeesPlayer;
	public float fieldOfViewAngle;
	public Vector3 personalLastSighting;
	public GameObject player;
	public SphereCollider col;
	public Transform[] patrolRoute;
	int patrolNum = 0;

	private Vector3 playerPosition;
	private UnityEngine.AI.NavMeshAgent nav;
	private Animator anim;
	private Vector3 lastPlayerSighting;
	//private HashIDs hash;

	void Start(){
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator>();
		col = GetComponent<SphereCollider>();

		//lastPlayerSighting = GameObject.FindObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();		
		//hash = GameObject.FindGameObjectWithTags(Tags.gameController).GetComponent<HashIDs>();
		//personalLastSighting = lastPlayerSighting.resetPosition;
		//prevSighting = lastPlayerSighting.resetPosition;
	}

	void Update () {
		/*
		if(lastPlayerSighting != prevSighting){
			personalLastSighting = lastPlayerSighting.position;
		}
		prevSighting = lastPlayerSighting.position;
		anim.SetBool(hash.playerInSightBool, SeesPlayer);
		*/

		playerPosition = new Vector3(player.transform.position.x, transform.position.y,player.transform.position.z); //guard sinks for some reason unless you tell it to stay level					
		if(SeesPlayer){
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
		}
		else{  //continue along patrol
			transform.position = Vector3.MoveTowards(transform.position, patrolRoute[patrolNum].position, speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, patrolRoute[patrolNum].position) < 0.02f){
				patrolNum++;
				//Debug.Log("heading to " + patrolNum);
				if(patrolNum >= patrolRoute.Length){
					patrolNum = 0;
				}
			}	
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			SeesPlayer = true;
			Debug.Log("Player Detected :Chasing");
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			Debug.Log("Player has been lost");
			SeesPlayer = false;
			}
	}

	void OnTriggerStay(Collider other){
		if(Vector3.Distance(transform.position, playerPosition) < 2f){
			Debug.Log("Gotcha!");
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else{
			gameObject.GetComponent<Renderer>().material.color = Color.red;	
				
			/*		
			if(other.gameObject == player){
				Debug.Log("Checking if can guard can still see player");
				//SeesPlayer = false; //reset to make sure we are still seeing player
				Vector3 direction = other.transform.position - transform.position;
				float angle = Vector3.Angle(direction,transform.forward);

				if(angle < fieldOfViewAngle * 0.5f){
				 	RaycastHit hit;
				 	if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)){ //col.radius
				 		Debug.Log("Shooting");
				 		if(hit.collider.gameObject == player){
						Debug.Log("Player Detected HIT");
				 			SeesPlayer = true;
				 			//lastPlayerSighting.position = player.transform.position;
				 		}
				 	}
				 }
			}
			*/
		}
	}

}
