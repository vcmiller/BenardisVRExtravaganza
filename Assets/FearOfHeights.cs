using UnityEngine;
using System.Collections;

public class FearOfHeights : MonoBehaviour {

    public float spookyHeight = 45f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y > spookyHeight)
        {
            Destroy(gameObject);
        }
	}
}
