using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

	bool firing = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") > 0 && !firing) {
			Debug.Log ("you are triggering");
			firing = true;
		}

		if (Input.GetAxis("Fire1") == 0) {
			//Debug.Log ("you not triggering");
			firing = false;
		}
	}
}
