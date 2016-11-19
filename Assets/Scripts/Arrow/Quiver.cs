using UnityEngine;
using System.Collections;

public class Quiver : MonoBehaviour {

    public ArrowBase arrow { get; set; }

    public ArrowBase[] selection;

    public Vector3 shoulder;

	// Use this for initialization
	void Start () {
        arrow = selection[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
