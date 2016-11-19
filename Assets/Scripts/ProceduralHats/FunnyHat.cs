using UnityEngine;
using System.Collections;

public class FunnyHat : MonoBehaviour {

    

    public float baseRadius = 0.5f;
    public float baseHeight = 0.3f;
    public float variance = 0.5f;
    public HatBase baseHat;

	// Use this for initialization
	void Start () {
        Instantiate(baseHat.gameObject, transform, false);
        HatBase hb = GetComponentInChildren<HatBase>();
        hb.radius = baseRadius + baseRadius * Random.Range(-variance, variance);
        hb.height = baseHeight + baseHeight * Random.Range(-variance, variance);
        hb.Form();

         for(int i = 0; i < 0; i++)
        {
            print(baseRadius + baseRadius * Random.Range(-variance, variance));
        }


	}

    void RandSculpt()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh; //Use a capsule
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

 
        int i = 1;
        while (i < vertices.Length)
        {
            float prevDist = Vector3.Distance(transform.position, Vector3.Cross(vertices[i - 1], transform.up));
          /*     vertices[i] += radius * Vector3.Cross(normals[i], transform.up);
            if (vertices[i].y > height)
            {
                vertices[i] = Vector3.Cross(normals[i], transform.up) + height * transform.up;
            }
            else if (vertices[i].y < height)
            {
                vertices[i] = Vector3.Cross(normals[i], transform.up) - height * transform.up;
            }*/

            i++;
        }
        mesh.vertices = vertices;
    }

    // Update is called once per frame
}
