using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward*speed;

    }
}
