using UnityEngine;
using System.Collections;

public class ArrowHand : MonoBehaviour {

    bool inputGrab;
    public bool grabbing;
    public Transform toGrab;

	// Use this for initialization
	void Start () {
        toGrab = null;
	}

    void Update()
    {
        if (grabbing && !inputGrab)
        {
            grabbing = false;
            toGrab = null;
            transform.DetachChildren();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>())
        {
            if (inputGrab)
            {
                grabbing = true;
                toGrab = col.transform;
                col.transform.SetParent(transform);
                col.transform.localPosition = Vector3.zero;
                col.transform.localRotation = Quaternion.identity;
            }
        }
    }

}
