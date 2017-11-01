using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public GameObject plane;

    public float velocity;
    public float acceleration;
    public float accelerationFactor;
    public float fractionFactor;
    public float rotationFactor;
    public Quaternion roll;
    public Quaternion pitch;



    private Transform planeTransform;
    private Rigidbody planeRigidBody;
	// Use this for initialization
	void Start () {
        velocity = 0;
        acceleration = 0;

        roll = Quaternion.identity;
        roll.x = 0;
        roll.y = 0;
        roll.z = 1;

        pitch = Quaternion.identity;
        pitch.x = 1;
        pitch.y = 0;
        pitch.z = 0;

        planeTransform = plane.transform;
        planeRigidBody = plane.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //Update velocity
        float rightTriggerAxis = Input.GetAxis("XBOX_Right_Trigger");
        float leftTriggerAxis = Input.GetAxis("XBOX_Left_Trigger");
        float leftStickXAxis = Input.GetAxis("XBOX_Left_Stick_X");
        float leftStickYAxis = Input.GetAxis("XBOX_Left_Stick_Y");
        Debug.Log("XBOX_Left_Stick_X:" + leftStickXAxis);
        Debug.Log("XBOX_Left_Stick_Y:" + leftStickYAxis);
        roll.w += leftStickXAxis * rotationFactor;
        if (roll.w > 2 * Mathf.PI)
            roll.w -= 2 * Mathf.PI;
        else if (roll.w < -2 * Mathf.PI)
            roll.w += 2 * Mathf.PI;
        pitch.w += leftStickYAxis * rotationFactor;
        if (pitch.w > 2 * Mathf.PI)
            pitch.w -= 2 * Mathf.PI;
        else if (pitch.w < -2 * Mathf.PI)
            pitch.w += 2 * Mathf.PI;
        planeTransform.rotation = roll * pitch;
        acceleration = (rightTriggerAxis - leftTriggerAxis) * accelerationFactor;
        velocity += (acceleration - velocity * fractionFactor) * Time.deltaTime;
        planeTransform.localPosition = planeTransform.localPosition + new Vector3(0, 0, velocity * Time.deltaTime);
    }
}
