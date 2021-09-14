using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player){
			Debug.Log("Changing Scnee");
			SceneManager.LoadScene("TestingScene", LoadSceneMode.Single);
		}
	}
}
