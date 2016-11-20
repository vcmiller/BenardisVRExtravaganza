using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {
    private float timeUntilNextSpawn;


    private Transform player;

    public GameObject prefab;
    public float spawnOffset = 100;

    public float minx = -50;
    public float maxx = 50;

    public float minTime = 2;
    public float maxTime = 10;

    public float scaleMin = 1;
    public float scaleMax = 1;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<HorseControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn < 0)
        {
            GameObject obj = (GameObject) Instantiate(prefab, new Vector3(Random.Range(minx, maxx), transform.position.y, player.position.z + spawnOffset), Quaternion.Euler(0, Random.Range(0, 360), 0));
            float f = Random.Range(scaleMin, scaleMax);
            obj.transform.localScale = new Vector3(f, f, f);

            timeUntilNextSpawn = Random.Range(minTime, maxTime);
        }
    }
}
