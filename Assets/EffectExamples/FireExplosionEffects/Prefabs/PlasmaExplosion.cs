using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaExplosion : MonoBehaviour {
    [SerializeField] float explosionDuration = 0.5f;
    float explosionTime;
    
	// Use this for initialization
	void Start () {
        explosionTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - explosionTime >= explosionDuration)
        {
            Destroy(gameObject);
        }
	}
}
