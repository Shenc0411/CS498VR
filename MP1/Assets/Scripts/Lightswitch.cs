using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour {
	public Light pointLight;
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			pointLight.color = new Color(Random.Range (0, 255)/ 100f, Random.Range (0, 255)/ 100f, Random.Range (0, 255)/ 100f);
			//pointLight.intensity = 1;
		}
	}
}
