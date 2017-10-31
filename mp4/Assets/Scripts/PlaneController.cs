using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public GameObject plane;

    public float velocity;
    public float acceleration;
    public float accelerationFactor;
    public float fractionFactor;
    public Quaternion direction;



    private Transform planeTransform;
    private Rigidbody planeRigidBody;
	// Use this for initialization
	void Start () {
        velocity = 0;
        acceleration = 0;
        direction = Quaternion.identity;
        planeTransform = plane.transform;
        planeRigidBody = plane.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //Update velocity
        float rightTriggerAxis = Input.GetAxis("XBOX_Right_Trigger");
        float leftTriggerAxis = Input.GetAxis("XBOX_Left_Trigger");
        acceleration = (rightTriggerAxis - leftTriggerAxis) * accelerationFactor;
        velocity += (acceleration - velocity * fractionFactor) * Time.deltaTime;
        planeTransform.localPosition = planeTransform.localPosition + new Vector3(0, 0, velocity * Time.deltaTime);
    }
}
