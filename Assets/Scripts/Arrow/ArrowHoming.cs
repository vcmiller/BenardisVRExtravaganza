using UnityEngine;
using System.Collections;

public class ArrowHoming : MonoBehaviour {
    public Transform target;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        return;
	    if (target)
        {
            rb.velocity = Vector3.RotateTowards(rb.velocity, target.position - transform.position, Time.deltaTime, 0);
            transform.forward = rb.velocity;
        }
	}
}
