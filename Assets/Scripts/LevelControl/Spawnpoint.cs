using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {

    static Vector3 directionOfPlay = new Vector3(0, 0, 1);

    public float distance;
    public Vector3 offset;
    Vector3 initPosition;
    Vector3 playerInitPosition;
    Transform player;

    Vector3 deltaPos {
        get
        {
            return player.position - playerInitPosition;
        }
    }

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<SteamVR_Camera>().transform;
        playerInitPosition = player.position;
        initPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = initPosition + Vector3.Project(deltaPos, directionOfPlay);
	}
}
