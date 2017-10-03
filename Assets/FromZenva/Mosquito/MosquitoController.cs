using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MosquitoController : MonoBehaviour {
    [SerializeField] float mosquitoSpeed = 2.0f;
    [SerializeField] float MinimumDistance = 0.3f;
    [SerializeField] GameObject plasmaExplosion;
    private VRInteractiveItem m_InteractiveItem;

     Transform player;
    bool isMoving = true;

    Rigidbody thisRb;
    private void Awake()
    {
        // set the target for the mosquitos
        player = Camera.main.transform;
        // get the interactive item component on this mosquito for event handling
        m_InteractiveItem = GetComponent<VRInteractiveItem>();
        thisRb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnClick += handleClick;
    }

   

    private void OnDisable()
    {
        m_InteractiveItem.OnClick -= handleClick;
    }



    private void Update()
    {
        if (isMoving)
        {
            moveMosquito();
        }
    }

    private void handleClick()
    {
        // the if statement prevents the mosquito from getting shot twice. 
        if (isMoving)
        {
            StartCoroutine( killMosquito());
        }
    }

    private void moveMosquito()
    {
        transform.LookAt(player); // comes towards the player pointed in the right direction
       float distance = (transform.position - player.position).magnitude;
        // the mosquitos stop before actually reaching you. 
        if (distance >= MinimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, mosquitoSpeed * Time.deltaTime);
        }
    }

    private IEnumerator killMosquito()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.9f);
        Instantiate(plasmaExplosion, transform.position, Quaternion.identity);
        thisRb.isKinematic = false; // this allows the mosquito to fall under gravity after getting hit
        isMoving = false; // stop the motion of the mosquito, It's also a flag for isKilled
        transform.Rotate(transform.forward, 180); // flips when it dies\
        
    }
}
