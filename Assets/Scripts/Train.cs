using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    Rigidbody rb;
    public float speed;

    public bool maintain = false;
    public bool respectGravity = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        SetSpeed();
    }
	
	// Update is called once per frame
	void Update () {
        if (maintain)
        {
            SetSpeed();
        }

    }

    void SetSpeed()
    {
        float y = rb.velocity.y;
        rb.velocity = transform.forward * speed;
        if (respectGravity)
        {
            rb.velocity = new Vector3(rb.velocity.x, y, rb.velocity.z);
        }
    }
}
