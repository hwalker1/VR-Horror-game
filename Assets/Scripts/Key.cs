using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public bool obtained = false;
	public GameObject player;

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			obtained = true;
			Debug.Log("Found the Key!");
		}
	}


}
