using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {
    [SerializeField] float minScale = 0.7f;
    [SerializeField] float maxScale = 2.0f;
	// Use this for initialization
	void Start () {
        //put position to the ground
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // random scale
        float scale = Random.Range(minScale, maxScale);
        transform.localScale *= scale;
        // random rotation about the vertical
        float rotationAngle = Random.Range(0, 360);
        transform.Rotate(Vector3.up , rotationAngle, Space.World);
	}
	
}
