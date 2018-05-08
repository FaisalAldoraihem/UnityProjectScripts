using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour {
    AudioSource Audio;
    Rigidbody rob;
    public float speed;
  
	void Start () {
        Audio = GetComponent<AudioSource>();
        rob = GetComponent<Rigidbody>();
        rob.velocity = transform.forward * speed;
        
    }
	
	
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
         
            Destroy(gameObject);
        }
        
    }
}
