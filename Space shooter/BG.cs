using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    public float scrollSpeed,TileSize;

    private Vector3 startPostation;
	void Start () {
        startPostation = transform.position;
	}
	
	
	void Update () {
        float newPos = Mathf.Repeat(Time.time*scrollSpeed,TileSize);

        transform.position = startPostation + Vector3.forward * newPos;
	}
}
