using UnityEngine;
using System.Collections;

public class HorseReadyCheck : MonoBehaviour {
    public Camera cam;
    ReadyIndicator ri;
	// Use this for initialization
	void Start () {
        ri = GetComponent<ReadyIndicator>();
	}
	
	// Update is called once per frame
	void Update () {
        ri.isReady = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition));
	}
}
