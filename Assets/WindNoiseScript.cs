using UnityEngine;
using System.Collections;

public class WindNoiseScript : MonoBehaviour {

    AudioSource src;

	// Use this for initialization
	void Start () {
        src = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        src.volume = (1 - Time.timeScale) / 4;
	}
}
