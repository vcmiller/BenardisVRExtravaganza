using UnityEngine;
using System.Collections;

public class Quiver : MonoBehaviour {

    public GameObject arrow { get; private set; }
    public ArrowBase[] selection;
    public float leashRange = 0.3f;

    public Vector3 shoulder;

	// Use this for initialization
	void Start () {
        ProjGenesis();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Vector3.Distance(arrow.transform.position, transform.position) >= leashRange)
        {
            ProjGenesis();
        }
	}

    void ProjGenesis()
    {
        arrow = (GameObject)Instantiate(selection[Random.Range(0, selection.Length)].gameObject, transform, false);
        arrow.GetComponent<Rigidbody>().isKinematic = true;
        arrow.transform.localPosition = Vector3.zero;
        arrow.transform.localRotation = Quaternion.identity;
    }
}
