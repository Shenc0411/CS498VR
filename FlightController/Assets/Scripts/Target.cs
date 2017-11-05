using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float respawnTime;
    private float timer;
    private bool timerEnabled;

    private void Start()
    {
        timer = 0;
        timerEnabled = false;
    }
    private void Update()
    {
        if (timerEnabled)
        {
            timer += Time.deltaTime;
            if(timer >= respawnTime)
            {
                this.GetComponent<Collider>().enabled = true;
                this.GetComponent<MeshRenderer>().enabled = true;
                timerEnabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.other.tag);
        if (collision.other.CompareTag("bullet"))
        {
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            timerEnabled = true;
        }
    }
}
