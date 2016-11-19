using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

    Transform notchObj;
    public Vector3 notch
    {
        get
        {
            return notchObj.position;
        }

    }

    public float arrowMagnetism = 0.3f;
    public float maxArrowDistance;
    public float maxVelocity;
    ArrowBase nocked;
    ArrowHand hand;

    // Use this for initialization
    void Start () {
        hand = FindObjectOfType<ArrowHand>();
        notchObj = transform.GetChild(0);
        nocked = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (nocked)
        {

            nocked.transform.position = notch + Mathf.Min(Vector3.Distance(notch, nocked.transform.position), maxArrowDistance) * -transform.forward;// Vector3.Cross(nocked.transform.localPosition, transform.up);
            nocked.transform.LookAt(notchObj);

            if (!hand.inputGrab)
            {
                print("releasing");
                Release();
            }
        }
        else
        {

            if (hand && hand.toGrab && Vector3.Distance(notch, hand.toGrab.position) <= arrowMagnetism)
            {
                print(hand.toGrab.name);
                Nock(hand.toGrab.GetComponent<ArrowBase>());
            }


        }
    }
 

    void Nock(ArrowBase ab)
    {
        nocked = ab;
    }

    void Release()
    {
        nocked.GetComponent<Rigidbody>().isKinematic = false;

        Rigidbody rb = transform.root.GetComponent<Rigidbody>();

        nocked.GetComponent<Rigidbody>().velocity = rb.velocity + transform.forward * maxVelocity * (Vector3.Distance(notch, nocked.transform.position) / maxArrowDistance);
        nocked = null;
    }
}
