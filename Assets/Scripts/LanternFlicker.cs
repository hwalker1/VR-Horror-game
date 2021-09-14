using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFlicker : MonoBehaviour {

	private Light lightComponent;
	private double range;

	private System.Random random;
	private const double MIN_RANGE = 4.0;
	private const double MAX_RANGE = 5.0;
	private bool oddFrame = true;

	void Start () {
		this.lightComponent = this.GetComponent<Light> ();
		range = 5;
		random = new System.Random ();
	}

	void Update () {
		if (oddFrame) {
			double randomNum = this.random.NextDouble () * 1 - 0.5;
			if (this.range + randomNum > MIN_RANGE && this.range + randomNum < MAX_RANGE) {
				this.range += randomNum;
				this.lightComponent.range = (float)this.range;
			}
		}
		oddFrame = !oddFrame;
	}
}
