using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveMon : MonoBehaviour {

    public float dodge, smoothing, Tilt;

    public Vector2 startWait,ManuverTime,ManuverWait;

    private float targetManeuver, currentSpeed;

    public Boundary boundray;

    Rigidbody rob;

	void Start ()
    {


        rob = GetComponent<Rigidbody>();

        currentSpeed = rob.velocity.z;

        

        StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1,dodge) * -Mathf.Sign(transform.position.x) ;

            yield return new WaitForSeconds(Random.Range(ManuverTime.x, ManuverTime.y));

            targetManeuver = 0;

            yield return new WaitForSeconds(Random.Range(ManuverWait.x, ManuverWait.y));


        }
    }

   private void FixedUpdate()
    {
         float newManuver = Mathf.MoveTowards(rob.velocity.x,targetManeuver,Time.deltaTime * smoothing);

        rob.velocity = new Vector3(newManuver, 0.0f, currentSpeed);
       
        rob.position = new Vector3
            (
            Mathf.Clamp(rob.position.x, boundray.xMin, boundray.XMax),
           0.0f,
            Mathf.Clamp(rob.position.z, boundray.zMin, boundray.ZMax)
            );
           rob.rotation = Quaternion.Euler(0.0f, 0.0f, rob.velocity.x * -Tilt);
    }
}
