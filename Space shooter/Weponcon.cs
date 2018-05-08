using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weponcon : MonoBehaviour {

    private AudioSource audiosourse;

    public GameObject shot;

    public Transform[] ShotSpawns;

    public float FireRate, Delay;
	void Start () {
        audiosourse = GetComponent<AudioSource>();
        InvokeRepeating("Fire",Delay,Random.Range(0.5f,FireRate));
	}

    private void Fire() {
      
      foreach(var ShotSpawn in ShotSpawns)
        {
            Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
        }
    
        audiosourse.Play();

    }
	
}
