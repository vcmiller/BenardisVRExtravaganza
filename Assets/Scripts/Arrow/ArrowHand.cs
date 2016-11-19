using UnityEngine;
using System.Collections;

public class ArrowHand : MonoBehaviour {

    public bool grabbing;
    public Transform toGrab;

	// Use this for initialization
	void Start () {
        toGrab = null;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>())
        {
            if (grabbing)
            {
                toGrab = col.transform;
                col.transform.SetParent(transform);
                col.transform.localPosition = Vector3.zero;
                col.transform.localRotation = Quaternion.identity;
            }
        }
    }

}
