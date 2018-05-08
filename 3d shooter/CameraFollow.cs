using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform Target;
    public float smoothin = 5f;
    Vector3 offset;

     void Start()
    {
        offset = transform.position - Target.position;
    }

     void FixedUpdate()
    {
        Vector3 TargetCamPos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position, TargetCamPos, smoothin * Time.deltaTime);
    }
}
