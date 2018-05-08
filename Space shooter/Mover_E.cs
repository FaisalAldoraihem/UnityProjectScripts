using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_E : MonoBehaviour {
    public float speed;

    Rigidbody rob;

	void Start () {
        rob = GetComponent<Rigidbody>();
        rob.velocity = transform.forward * speed;
    }
    

}
