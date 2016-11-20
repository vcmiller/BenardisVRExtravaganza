using UnityEngine;
using System.Collections;

public class TrainSpanwer : MonoBehaviour {
    private Transform player;

    public GameObject locomotive;
    public GameObject car;

    public int maxLength;
    public int minLength;
    public float carLength;

    public Vector3 dir;

    public float minTime;
    public float maxTime;

    public float speed;
    public float offset;

    float timeLeft;

    public bool atPlayerOnFirst = false;
    public bool first = true;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<HorseControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0)
        {
            SpawnTrain();
            timeLeft = Random.Range(minTime, maxTime);
        } else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void SpawnTrain()
    {
        Vector3 poff = player.position;
        poff.y = 0;
        poff.x = 0;

        Vector3 pos = transform.position + poff + (atPlayerOnFirst && first ? Vector3.zero : dir * offset);
        first = false;

        Train train = ((GameObject)Instantiate(locomotive, pos, Quaternion.LookRotation(dir, Vector3.up))).GetComponent<Train>();
        train.speed = -speed;

        int numCars = Random.Range(minLength, maxLength);

        for (int i = 1; i < numCars; i++)
        {
            pos += dir * carLength;

            Transform train2 = ((GameObject)Instantiate(car, pos, Quaternion.LookRotation(dir, Vector3.up))).transform;

            train2.transform.parent = train.transform;
        }
    }
}
