using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    Rigidbody rigidbody;
    public float speed;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = transform.forward*speed;

    }
}
