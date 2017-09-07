using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDimmer : MonoBehaviour {

    public Light pointLight;
    public Transform playerTransform;
    private Vector3 lightPos = new Vector3(0, 5, 0);
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = playerTransform.localPosition;
        pointLight.intensity = 10 / Vector3.Distance(playerPos, lightPos);
	}
}
