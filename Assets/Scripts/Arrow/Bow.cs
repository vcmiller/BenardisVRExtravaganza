using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bow : MonoBehaviour {
    AudioSource src;
    public AudioClip[] shootSounds;

    Transform target;

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
    public ArrowBase nocked
    {
        get; private set;
    }
    ArrowHand hand;
    LineRenderer lr;

    // Use this for initialization
    void Start () {
        hand = FindObjectOfType<ArrowHand>();
        notchObj = transform.GetChild(0);
        lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(51);
        nocked = null;
	}
	
	// Update is called once per frame
	void Update () {
        lr.enabled = nocked;
        src.enabled = nocked;
        if (nocked)
        {
            nocked.transform.position = notch + Mathf.Min(Vector3.Distance(notch, nocked.transform.position), maxArrowDistance) * -notchObj.forward;// Vector3.Cross(nocked.transform.localPosition, transform.up);
            nocked.transform.up = notch - nocked.transform.position;

            if (!hand.inputGrab)
            {
                Release();
            }

            src.volume = NockedPotentialVelocity() / maxVelocity;
            src.pitch = NockedPotentialVelocity() / maxVelocity;

            SteamVR_Controller.Input(0).TriggerHapticPulse();

            ParabolicCast();
        }
        else
        {

            if (hand && hand.toGrab && Vector3.Distance(notch, hand.toGrab.position) <= arrowMagnetism)
            {
                Nock(hand.toGrab.GetComponent<ArrowBase>());
            }


        }
    }
 
    void ParabolicCast()
    {
        if (!nocked)
        {
            return;
        }

        List<RaycastHit> lrHits;
        List<Vector3> lrPoints;

        Rigidbody rb = transform.root.GetComponent<Rigidbody>();
        GetArcHits(out lrHits, out lrPoints, notch, notchObj.forward * NockedPotentialVelocity(), Physics.gravity, 0.25f, 1f);

        target = null;
        foreach (RaycastHit hit in lrHits)
        {
            if (hit.transform.root.GetComponentInChildren<Enemy>())
            {
                target = hit.transform;
            }
        }


        lr.SetVertexCount(lrPoints.Count);
        lr.SetPositions(lrPoints.ToArray());
        
    }

    public static void GetArcHits(out List<RaycastHit> Hits, out List<Vector3> Points, Vector3 vStart, Vector3 vVelocity, Vector3 vAcceleration, float fTimeStep = 0.05f, float fMaxtime = 10f, bool bIncludeUnits = false, bool bDebugDraw = false)
    {
        Hits = new List<RaycastHit>();
        Points = new List<Vector3>();

        Vector3 prev = vStart;
        Points.Add(vStart);

        for (int i = 1; ; i++)
        {
            float t = fTimeStep * i;
            if (t > fMaxtime) break;
            Vector3 pos = PlotTrajectoryAtTime(vStart, vVelocity, vAcceleration, t);

            RaycastHit hit;
            if (Physics.Linecast(prev, pos, out hit))
            {
                Hits.Add(hit);
                Points.Add(pos);
                break;
            }
            else
            {
                Points.Add(pos);
            }
 
            prev = pos;
        }
    }
    public static Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, Vector3 acceleration, float fTimeSinceStart)
    {
        return start + startVelocity * fTimeSinceStart + acceleration * fTimeSinceStart * fTimeSinceStart * 0.5f;
    }

    void Nock(ArrowBase ab)
    {
        nocked = ab;
    }

    void Release()
    {
        AudioSource.PlayClipAtPoint(shootSounds[Random.Range(0, shootSounds.Length)], transform.position);

        nocked.GetComponent<Rigidbody>().isKinematic = false;

        Rigidbody rb = transform.root.GetComponent<Rigidbody>();

        nocked.GetComponent<Rigidbody>().velocity = transform.forward * NockedPotentialVelocity(); //rb.velocity

        nocked.GetComponent<ArrowHoming>().target = target;
        

        nocked = null;
    }

    public float NockedPotentialVelocity()
    {
        if (!nocked) { return 0; }
        return maxVelocity * Mathf.Pow(Vector3.Distance(notch, nocked.transform.position) / maxArrowDistance, 4);
    }
}
