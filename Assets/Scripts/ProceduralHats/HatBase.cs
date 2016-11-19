using UnityEngine;
using System.Collections;

public class HatBase : MonoBehaviour {

    public float radius;
    public float height;
    public Vector3 top
    {
        get
        {
            return transform.position + height * transform.up;
        }
    }


	// Update is called once per frame
	public void Form () {
        Mesh mesh = GetComponent<MeshFilter>().mesh; //Use a capsule
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] += radius * Vector3.Cross(normals[i], transform.up);
            if (vertices[i].y > height)
            {
                vertices[i] = Vector3.Cross(normals[i], transform.up) + height * transform.up;
            }
            else if (vertices[i].y < height)
            {
                vertices[i] = Vector3.Cross(normals[i], transform.up) - height * transform.up;
            }

            i++;
        }
        mesh.vertices = vertices;
    }
}
