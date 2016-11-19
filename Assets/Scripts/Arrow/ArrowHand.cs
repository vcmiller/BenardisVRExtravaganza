using UnityEngine;
using System.Collections;

public class ArrowHand : MonoBehaviour
{

    public SteamVR_TrackedObject controller { get; private set; }
    public SteamVR_Controller.Device input { get { return SteamVR_Controller.Input((int)controller.index); } }

    public bool inputGrab
    {
        get
        {
            return input.GetPress(SteamVR_Controller.ButtonMask.Trigger);
        }
    }
    public bool grabbing;
    public Transform toGrab;

    // Use this for initialization
    void Start()
    {
        toGrab = null;
        controller = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {

        if (grabbing && !inputGrab)
        {
            grabbing = false;
            toGrab.parent = null;
            toGrab.GetComponent<Rigidbody>().isKinematic = false;
            toGrab = null;
        }

        if (inputGrab && !grabbing)
        {
            foreach (Collider col in Physics.OverlapSphere(transform.position, 0.3f)) {

                if ((col.transform.GetComponent<ArrowBase>()))
                {

                    grabbing = true;
                    toGrab = col.transform;
                    toGrab.SetParent(transform);
                    toGrab.localPosition = Vector3.zero;
                    toGrab.localRotation = Quaternion.Euler(-90, 0, 0);
                    col.GetComponent<Rigidbody>().isKinematic = true;
                    // toGrab.localPosition = transform.up / -4;
                    break;
                }
            }       
        }
    }
}
