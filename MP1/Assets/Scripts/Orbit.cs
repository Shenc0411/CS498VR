using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	
	public Transform Center;
	void Update () {
		Center.Rotate (new Vector3 (0, 40 * Time.deltaTime, 0));
	}
}
