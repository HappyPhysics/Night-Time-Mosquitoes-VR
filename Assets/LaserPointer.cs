using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class LaserPointer : MonoBehaviour {

	LineRenderer lineRend;

	Reticle reticle;

	Vector3[] laserEndPoints = new Vector3[2];
	// Use this for initialization
	void Awake () {
		lineRend = GetComponent<LineRenderer> ();
		reticle = FindObjectOfType<Reticle> ();
	}
	
	// Update is called once per frame
	void Update () {
		laserEndPoints [0] = transform.position;
		laserEndPoints [1] = reticle.ReticleTransform.position;

		lineRend.SetPositions (laserEndPoints);
	}
}
