using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour {

    public GameObject targetPrefab;
    public int toatlTargetNum;
	// Use this for initialization
	void Start () {
	    
        for(int i = 0; i < toatlTargetNum; i++)
        {
            float x = Random.Range(1024, 2048 + 1024);
            float z = Random.Range(1024, 2048 + 1024);
            float minY = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));
            float y = Random.Range(minY + 100, minY + 300);
            Instantiate(targetPrefab, new Vector3(x, y, z), Quaternion.identity, this.transform);
        }

	}
	
}
