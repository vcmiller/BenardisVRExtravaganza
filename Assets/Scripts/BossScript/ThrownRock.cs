using UnityEngine;
using System.Collections;

public class ThrownRock : MonoBehaviour {

    static float speed = 3f;
    Vector3 target;

	// Use this for initialization
	void Start () {
        target = FindObjectOfType<SteamVR_Camera>().transform.position;
        transform.LookAt(target);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += speed * transform.forward * Time.deltaTime;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>())
        {
            Destroy(gameObject);
        }
    }
}
