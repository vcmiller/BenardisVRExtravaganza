using UnityEngine;
using System.Collections;

public class DustDevilAttacks : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject[] spawnpoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ThrowRock()
    {
        GameObject rock = GetComponentInChildren<OrbitRock>().gameObject;

        if(rock == null)
        {
            return;
        }
        rock.transform.parent = null;
        Destroy(rock.GetComponent<OrbitRock>());
        rock.AddComponent<ThrownRock>();
    }

    void SummonRiders()
    {
        GameObject[] points = new GameObject[3];
        for(int i = 0; i < points.Length; i++)
        {
            int index = Random.Range(0, spawnpoints.Length);
            if(System.Array.IndexOf(points, spawnpoints[index]) < 0)
            {
                i--;
            }else
            {
                points[i] = spawnpoints[index];
            }
        }        

        foreach(GameObject go in points)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], go.transform.position, Quaternion.identity);
        }
    }
}
