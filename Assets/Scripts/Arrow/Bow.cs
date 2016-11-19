﻿using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

    public Vector3 notch;
    public float maxArrowDistance;
    public float maxVelocity;
    ArrowBase nocked;
    ArrowHand hand;

    bool lastGrabState;

    // Use this for initialization
    void Start () {
        hand = FindObjectOfType<ArrowHand>();
        lastGrabState = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (nocked)
        {
            if (Vector3.Distance(notch, nocked.transform.position) > maxArrowDistance)
            {
                nocked.transform.position = (nocked.transform.position - notch).normalized * maxArrowDistance;
            }
            nocked.transform.rotation = Quaternion.LookRotation(notch - nocked.transform.position);
        }

        if(Vector3.Distance(notch, hand.toGrab.position) <= 0.3f)
        {
            Nock(hand.toGrab.GetComponent<ArrowBase>());
        }

        if (nocked && !hand.grabbing)
        {
            Release();
        }
    }
 

    void Nock(ArrowBase ab)
    {
        nocked = ab;
    }

    void Release()
    {
        nocked.GetComponent<Rigidbody>().velocity = transform.forward * maxVelocity * (Vector3.Distance(notch, nocked.transform.position) / maxArrowDistance);
    }
}
