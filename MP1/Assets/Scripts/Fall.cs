using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
	public Rigidbody sphereRigidbody;
	
	void OnTriggerEnter(Collider other){
		sphereRigidbody.useGravity = true;
	}
}
