using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour {

    public bool positionTracking = true;
    public bool rotationTracking = true;
    public Transform mainCameraParentTransform;
    public Transform mainCameraTransform;

    private Vector3 lastMainCameraPosition;
    //private Vector3 lastMainCameraParentPosition;
    private Quaternion lastMainCameraRotation;
    //private Quaternion lastMainCameraParentRotation;
	// Use this for initialization
	void Start () {
        lastMainCameraPosition = mainCameraTransform.position;
        lastMainCameraRotation = mainCameraTransform.rotation;
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
        if (!rotationTracking)
        {
            mainCameraParentTransform.rotation = (lastMainCameraRotation * Quaternion.Inverse(mainCameraTransform.rotation)) * mainCameraParentTransform.rotation;
        }
        if (!positionTracking)
        {
            mainCameraParentTransform.position -= (mainCameraTransform.position - lastMainCameraPosition);
        }
        lastMainCameraPosition = mainCameraTransform.position;
        lastMainCameraRotation = mainCameraTransform.rotation;
	}
}
