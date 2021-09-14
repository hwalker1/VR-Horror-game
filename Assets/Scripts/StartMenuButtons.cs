using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButtons : MonoBehaviour {

	public void PlayGame()
	{
		this.gameObject.SetActive (false);
	}

	public void ExitGame()
	{
		Debug.Log ("QUIT GAME");
		Application.Quit();
	}

}
