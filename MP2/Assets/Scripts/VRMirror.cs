using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour {
    public Transform cameraTransform;
    public Transform cameraParentTransform;
    public Transform objectTransform;
    public Transform mirrorTransform;

    private Vector3 cameraOrigin;
    private Vector3 objectOrigin;
    private enum Mode {Normal, Match, Mirror}
    private Mode mode;
	// Use this for initialization
	void Start () {
        cameraOrigin = cameraTransform.position;
        objectOrigin = objectTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(objectTransform.position);
        if (Input.GetKeyDown(KeyCode.M))
        {
            mode = (Mode)(((int)mode + 1) % 3);
        }
        if (mode == Mode.Match)
        {
            objectTransform.position = objectOrigin + (cameraTransform.position - cameraOrigin);
            objectTransform.rotation = cameraTransform.rotation;
            objectTransform.Rotate(0, -90, 0);
        }
        else if(mode == Mode.Mirror)
        {
            Vector3 posTemp = objectOrigin + (cameraTransform.position - cameraOrigin);
            posTemp.z = 2 * mirrorTransform.position.z - cameraTransform.position.z;
            objectTransform.position = posTemp;
            Quaternion rotTemp = cameraTransform.rotation;
            rotTemp.x = -rotTemp.x;
            rotTemp.y = -rotTemp.y;
            //rotTemp.z = -rotTemp.z;
            objectTransform.rotation = rotTemp;
            objectTransform.Rotate(0, 90, 0);
        }
	}
}
