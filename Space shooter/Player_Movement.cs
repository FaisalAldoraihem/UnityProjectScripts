using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, XMax, zMin, ZMax;
}
public class Player_Movement : MonoBehaviour {

    public GameObject shot;

    public Transform[] shotSpawns;

    public float fireRate = 0.5f;

    float nextFire = 0.0f;

    public int speed;

   public float PowerTime = 10f;

    public float Tilt;

    public Boundary boundray;

    Rigidbody rob;

    AudioSource[] AudioSources;

    private Quaternion calibrationQuaternion;

    public T Pad;

    public SimpleTouchAreaB B;

    bool powerUp = false;

    void Start() {

        //CalibrateAccelerometer();
        rob = GetComponent<Rigidbody>();
        AudioSources = GetComponents<AudioSource>();
       
    }

    void Update()
    {
        if (Input.GetButton("Fire1") /*B.CanFire()*/&& Time.time > nextFire)
        {
            if (powerUp)
            {
                StartCoroutine(Powerup());
            }
            else
            {
                nextFire = Time.time + fireRate;

                Instantiate(shot, shotSpawns[0].position, shotSpawns[0].rotation);

                AudioSources[0].Play();
            }
            
        }

        
    }

   /* void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }


    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }*/



    IEnumerator Powerup()
    {
        if (Input.GetButton("Fire1") /*B.CanFire()*/&& Time.time > nextFire)
        {

                nextFire = Time.time + fireRate;

                foreach (Transform shotSpawn in shotSpawns)
                {
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            AudioSources[0].Play();              
            }

        yield return new WaitForSeconds(PowerTime);
               
        powerUp = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerUp = true;
            AudioSources[1].Play();
        }
    }

    void FixedUpdate() {
       
                float MoveHorizontal = Input.GetAxis("Vertical");
                float MoveVertical = Input.GetAxis("Horizontal");

                rob.velocity = new Vector3(MoveHorizontal, 0.0f, MoveVertical) * speed;
        /*
               Vector3 accelerationRaw = Input.acceleration;

               Vector3 acceleration = FixAcceleration(accelerationRaw);

                Vector3 movment =new Vector3(acceleration.x, 0.0f,acceleration.y);


       Vector2 direction = Pad.GetDirection();

        Vector3 movment = new Vector3(direction.x, 0.0f, direction.y);

        rob.velocity = movment * speed;
         */
        rob.position = new Vector3(

            Mathf.Clamp(rob.position.x, boundray.xMin, boundray.XMax),
            0.0f,
            Mathf.Clamp(rob.position.z, boundray.zMin, boundray.ZMax)

            );

        rob.rotation = Quaternion.Euler(0.0f, 0.0f, rob.velocity.x * -Tilt);
    }
   





}

