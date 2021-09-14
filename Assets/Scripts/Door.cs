using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject player;
	public GameObject key;

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player && key.GetComponent<Key>().obtained){
			Debug.Log("opened Door");
			//gameObject.GetComponent<BoxCollider>().Disabled;
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
			
	}

}
