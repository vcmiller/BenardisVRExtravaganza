using UnityEngine;
using System.Collections;

public class OrbitRock : MonoBehaviour {

    public Mesh[] meshes;
    Transform center;
    Vector3 axis;
    float radius;
    public float speed;
    Rigidbody rb;


	// Use this for initialization
	void Start () {
        center = FindObjectOfType<DustDevilHeart>().transform;
        transform.parent = center;
        axis = transform.up;
        radius = Vector3.Distance(transform.position, center.position);
        GetComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = 10 * Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
        if (center)
        {
            transform.RotateAround(center.position, axis, speed);
          //  transform.LookAt(center);
        }

        rb.useGravity = !center;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>())
        {
            Destroy(gameObject);
        }
    }
}
