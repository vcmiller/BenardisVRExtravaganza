using UnityEngine;
using System.Collections;

public class BoundsObject : MonoBehaviour {
    private PlayerBounds bounds;

	// Use this for initialization
	void Start () {
        bounds = FindObjectOfType<PlayerBounds>();
	}
	
	// Update is called once per frame
	void Update () {
        float z = transform.position.z;

        if (Mathf.Abs(z - bounds.transform.position.z) > bounds.bounds)
        {
            Destroy(gameObject);
        }
	}
}
