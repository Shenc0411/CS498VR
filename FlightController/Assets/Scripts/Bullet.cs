using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float velocity;
    public float maximumLifeSpan;
    public float timeExisted;
    public Vector3 forward;
    // Update is called once per frame
    private void FixedUpdate()
    {
        timeExisted += Time.fixedDeltaTime;
        if (timeExisted >= maximumLifeSpan)
        {
            Destroy(gameObject);
        }
        this.transform.position += forward * velocity * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("target"))
        {
            Debug.Log("Hit Target!");
            GameObject.Destroy(collision.other.gameObject);
            Destroy(gameObject);
        }
    }
}
