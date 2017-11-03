using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public GameObject plane;
    public GameObject propeller;
    public GameObject bulletPrefab;
    public Transform gunTransform;
    public Transform bulletParent;
    public Transform headTransform;
    public Vector3 originPosition;
    public Quaternion originRotation;
    public float minimumVelocity;
    public float maximumVelocity;
    public float maximumRotation;
    public float velocity;
    public float acceleration;
    public float accelerationFactor;
    public float frictionFactor;
    public float rotationFrictionFactor;
    public float pitchFactor;
    //public float yawFactor;
    public float rollFactor;
    public float pitchAccerlation;
    //public float yawAccerlation;
    public float rollAccerlation;
    public float pitchVelocity;
    //public float yawVelocity;
    public float rollVelocity;
    public int controller;
    private Transform planeTransform;
    private Rigidbody planeRigidBody;
    private Transform propellerTransform;
    private Vector3 forward;
	// Use this for initialization
	void Start () {
        
        planeTransform = plane.transform;
        planeRigidBody = plane.GetComponent<Rigidbody>();
        propellerTransform = propeller.transform;
        originPosition = planeTransform.position;
        originRotation = planeTransform.rotation;
        ResetPlane();

	}

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            ShootBullet();
        }
    }

    private void FixedUpdate ()
    {

        //Update velocity
        float AccAxis = 0;
        float DeAccAxis = 0;
        float XAxis = 0;
        float YAxis = 0;

        if (controller == 1)
        {
            AccAxis = Input.GetAxis("XBOX_Right_Trigger");
            DeAccAxis = Input.GetAxis("XBOX_Left_Trigger");
            XAxis = Input.GetAxis("XBOX_Left_Stick_X");
            YAxis = Input.GetAxis("XBOX_Left_Stick_Y");
        }
        else if (controller == 2)
        {
            AccAxis = Input.GetAxis("Oculus_GearVR_RThumbstickY");
            //leftTriggerAxis = Input.GetAxis("Oculus_GearVR_LThumbstickX");
            Debug.Log(AccAxis);
            XAxis = Input.GetAxis("Oculus_GearVR_LThumbstickX");
            YAxis = -Input.GetAxis("Oculus_GearVR_LThumbstickY");
        }

        Vector3 up = planeTransform.up;
        //Debug.Log(up);
        rollAccerlation = -XAxis * rollFactor;
        pitchAccerlation = -YAxis * pitchFactor;

        rollVelocity += (rollAccerlation - (rollVelocity) * rotationFrictionFactor) * Time.fixedDeltaTime;
        //yawVelocity += (yawAccerlation - yawVelocity * rotationFrictionFactor) * Time.deltaTime;
        pitchVelocity += (pitchAccerlation - (pitchVelocity) * rotationFrictionFactor) * Time.fixedDeltaTime;
        
        
        planeTransform.Rotate(pitchVelocity * Time.fixedDeltaTime, 0, rollVelocity * Time.fixedDeltaTime);

        if(Mathf.Abs(XAxis) + Mathf.Abs(YAxis) < 0.15f)
        {
            //Debug.Log(leftStickXAxis + "," + leftStickYAxis);
            //planeTransform.rotation = Quaternion.Lerp(planeTransform.rotation, originRotation, 0.025f);
        }

        acceleration = (AccAxis - DeAccAxis) * accelerationFactor;
        velocity += (acceleration - velocity * frictionFactor) * Time.fixedDeltaTime;
        if (velocity < minimumVelocity)
            velocity = minimumVelocity;
        else if (velocity > maximumVelocity)
            velocity = maximumVelocity;
        Vector3 movement = planeTransform.forward * velocity * Time.fixedDeltaTime;
        planeTransform.position += movement;

        propellerTransform.Rotate(0, 0, acceleration * Time.deltaTime * 7f + 10f);

        headTransform.localPosition = new Vector3(0, 0, -(0.001f * (velocity - minimumVelocity)));

        forward = headTransform.forward;

    }

    private void OnCollisionEnter(Collision collision)
    {
        planeTransform.position = originPosition;
        ResetPlane();
    }

    private void ResetPlane()
    {
        
        velocity = minimumVelocity;
        acceleration = 0;
        pitchAccerlation = 0;
        //yawAccerlation = 0;
        rollAccerlation = 0;
        pitchVelocity = 0;
        //yawVelocity = 0;
        rollVelocity = 0;
        //totalPitch = 0;
        //totalRoll = 0;
        planeRigidBody.angularVelocity = Vector3.zero;
        planeRigidBody.velocity = Vector3.zero;
        planeTransform.rotation = originRotation;
    }

    private void ShootBullet()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation, bulletParent);
        Bullet bulletScript = bulletGO.GetComponent<Bullet>();
        bulletScript.forward = forward;
    }
}
