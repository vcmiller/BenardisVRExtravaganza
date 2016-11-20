using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    Rigidbody rb;
    public float speed;

    public bool maintain = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (maintain)
        {

            rb.velocity = transform.forward * speed;
        }

    }
}
