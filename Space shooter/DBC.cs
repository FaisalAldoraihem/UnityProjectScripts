using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBC : MonoBehaviour {

    public GameObject explosion, PE;
    
    public int ScoreValue;

    private GameCon gamecon;

    private void Start()

    {
        GameObject gameConObj = GameObject.FindWithTag("GameController");

        if(gameConObj != null)
        {
            gamecon = gameConObj.GetComponent<GameCon>();
        }

        if(gamecon == null)
        {
            Debug.Log ("Cannot find game con script help");
        }
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Boundray") || other.CompareTag("Enemy") || other.CompareTag("Powerup"))
        {
            return;
        }

        if (explosion != null) { 

        Instantiate(explosion, transform.position, transform.rotation);
    }
        if (other.CompareTag("player")) {
            
            Instantiate(PE, other.transform.position, other.transform.rotation);
            gamecon.Gameova();
            
    }
        gamecon.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Boundray"))
        {

            Destroy(gameObject);

        }
    }


}
