using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public GameObject ragdollPrefab;
    public bool kill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (kill)
        {
            Kill();
        }
	}

    void Kill()
    {
        Instantiate(ragdollPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
