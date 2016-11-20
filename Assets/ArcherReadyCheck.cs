using UnityEngine;
using System.Collections;

public class ArcherReadyCheck : MonoBehaviour {

    float readyCount = 0;
    ReadyIndicator ri;
    // Use this for initialization
	void Start () {
        ri = GetComponent<ReadyIndicator>();
	}
	
	// Update is called once per frame
	void Update () {
        readyCount -= Time.deltaTime;
        if(readyCount < 0)
        {
            readyCount = 0;
        }

        ri.isReady = readyCount > 0;
	}


    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>())
        {
            readyCount = 1;
        }
    }
}
