using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour {

    public bool positionTracking = true;
    public bool rotationTracking = true;
    public Transform mainCameraParentTransform;
    public Transform mainCameraTransform;

    private Vector3 mainCameraOriginalPosition;
    private Vector3 mainCameraParentOriginalPosition;
    private Quaternion mainCameraOriginalRotation;
    private Quaternion mainCameraParentOriginalRotation;
	// Use this for initialization
	void Start () {
        mainCameraOriginalPosition = mainCameraTransform.position;
        mainCameraParentOriginalPosition = mainCameraParentTransform.position;
        mainCameraOriginalRotation = mainCameraTransform.rotation;
        mainCameraParentOriginalRotation = mainCameraParentTransform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            positionTracking = !positionTracking;
            Debug.Log("Position Tracking: " + positionTracking);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            rotationTracking = !rotationTracking;
            Debug.Log("Rotation Tracking: " + rotationTracking);
        }
        if (!positionTracking)
        {

        }
        if (!positionTracking)
        {
            mainCameraParentTransform.position = mainCameraParentOriginalPosition + (mainCameraParentTransform.position - mainCameraOriginalPosition);
        }
	}
}
