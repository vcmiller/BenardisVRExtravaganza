using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {
    Vector3 offset;
    Transform player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<HorseControl>().transform;
        offset = transform.position - player.position;
        offset.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
	}
}
