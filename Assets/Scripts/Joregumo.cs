using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joregumo : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<CoverEars>().earsCovered){
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else{
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
	}
}
