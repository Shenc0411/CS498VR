using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour {

    public bool positionTracking = true;
    public bool rotationTracking = true;
    public Transform mainCameraParentTransform;
    public Transform mainCameraTransform;

    private Vector3 lastMainCameraPosition;
    private Vector3 lastMainCameraParentPosition;
    private Quaternion lastMainCameraRotation;
    private Quaternion lastMainCameraParentRotation;
	// Use this for initialization
	void Start () {
        lastMainCameraPosition = mainCameraTransform.position;
        lastMainCameraParentPosition = mainCameraParentTransform.position;
        lastMainCameraRotation = mainCameraTransform.rotation;
        lastMainCameraParentRotation = mainCameraParentTransform.rotation;
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
            mainCameraParentTransform.position = lastMainCameraParentPosition - (mainCameraTransform.position - lastMainCameraPosition);
        }
        if (!rotationTracking)
        {
            mainCameraParentTransform.rotation = lastMainCameraRotation * Quaternion.Inverse(mainCameraTransform.rotation) * lastMainCameraParentRotation;
        }
        
        lastMainCameraPosition = mainCameraTransform.position;
        lastMainCameraRotation = mainCameraTransform.rotation;
        lastMainCameraParentPosition = mainCameraParentTransform.position;
        lastMainCameraParentRotation = mainCameraParentTransform.rotation;
	}
}
