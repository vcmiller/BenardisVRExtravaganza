using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private Transform player;

    public GameObject prefab;
    public float spawnOffset = 100;
    private float lastSpawnZ;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<HorseControl>().transform;

        lastSpawnZ = player.transform.position.z - spawnOffset;
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}

    void Spawn()
    {
        while (lastSpawnZ - player.transform.position.z < spawnOffset)
        {
            lastSpawnZ += 20;
            GameObject obj = Instantiate(prefab);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, lastSpawnZ);
            obj.transform.rotation = transform.rotation;
        }
    }
}
