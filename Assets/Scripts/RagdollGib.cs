using UnityEngine;
using System.Collections;

public class RagdollGib : MonoBehaviour {
    private float startTime;
    public float timeToLive = .3f;
    public float gibLifetime = 3.0f;

    void Start()
    {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - startTime >= timeToLive)
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

            foreach (Joint joint in GetComponentsInChildren<Joint>())
            {
                Destroy(joint);
            }

            foreach (Rigidbody rb in rigidbodies)
            {
                rb.transform.parent = null;
                Destroy(rb.GetComponent<Collider>(), gibLifetime);
                Destroy(rb.gameObject, gibLifetime + 1.0f);
            }

            Destroy(gameObject, gibLifetime + 1.0f);
        }
	}
}
