
using UnityEngine;
using System.Collections;

public class SpawnerBrain : MonoBehaviour {

    public Transform[] spawnPoints;

    public GameObject[] trains;
    public GameObject[] enemies;
    public GameObject[] scenery;

    public float trainTimer;
    public float enemyTimer;
    public float sceneryTimer;

    // Use this for initialization
    void Start () {
        spawnPoints = FindObjectOfType<Spawnpoint>().GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnIfTime(trains, trainTimer);
        SpawnIfTime(enemies, enemyTimer);
        SpawnIfTime(scenery, sceneryTimer);
    }

    void SpawnIfTime(GameObject[] objs, float max_time)
    {
        if (TimeCheck(max_time))
        {
            Instantiate(objs[Random.Range(0, objs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }

    bool TimeCheck(float max_time)
    {
        return (max_time % Time.time <= Time.deltaTime);
    }
}
