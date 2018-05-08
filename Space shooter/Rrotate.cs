using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rrotate : MonoBehaviour {

    public float tumble;
    Rigidbody rob;
	void Start () {
        rob = GetComponent<Rigidbody>();
        rob.angularVelocity = Random.insideUnitSphere * tumble; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
