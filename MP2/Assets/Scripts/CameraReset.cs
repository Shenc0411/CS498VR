using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour {

    public Transform cameraTransform;
    public Transform cameraParentTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cameraParentTransform.position = -cameraTransform.localPosition;
        }
	}
}
