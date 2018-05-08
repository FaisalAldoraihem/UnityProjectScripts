using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Rigidbody rob;
    public float speed;

	void Start () {

        rob = GetComponent<Rigidbody>();

        rob.velocity = transform.forward * speed;
	}


    
}
