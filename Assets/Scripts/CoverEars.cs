using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverEars : MonoBehaviour {

	public Transform leftHand, rightHand;
	public Transform head;
	public bool earsCovered = false;

	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(leftHand.position, head.position) < 0.2 && Vector3.Distance(rightHand.position, head.position) < 0.2){
			Debug.Log("Ears covered");
			earsCovered = true;
		}
		else{
			Debug.Log("Ears Uncovered");
			earsCovered = false;
		}
	}
}
