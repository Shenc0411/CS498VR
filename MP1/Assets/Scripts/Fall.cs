using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
	public Rigidbody sphereRigidbody;
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		sphereRigidbody.useGravity = true;
	}
}
