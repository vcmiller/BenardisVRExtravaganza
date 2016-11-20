using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float minProximity = 5.0f;
    Transform player;
    float distance
    {
        get
        {
            return Vector3.Distance(transform.position, player.position);
        }
    }

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<HorseControl>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = Mathf.Min((distance / minProximity), Time.timeScale);
	}
}
