using UnityEngine;
using System.Collections;

public class DustDevilHeart : MonoBehaviour {

    public float health = 100.0f;
    public float damage = 5.0f;

    public GameObject partPrefab;
    public float outerRadius;
    public float innerRadius;


    // Use this for initialization
    void Start () {
        HyperCubeRejection(innerRadius, 1);
        HyperCubeRejection(outerRadius, -0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        float angle = 3 * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(angle, angle, angle);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ArrowBase>()) {

            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }            

    }


    void HyperCubeRejection(float radius, float direction)
    {
        float a = 4 * Mathf.PI / 50;
        float d = Mathf.Sqrt(a);
        float m_theta = Mathf.Round(Mathf.PI / d);
        float d_theta = Mathf.PI / m_theta;
        float d_phi = a / d_theta;
        for (int m = 0; m < m_theta; m++)
        {
            float theta = Mathf.PI * (m + 0.5f) / (m_theta);
            float m_phi = Mathf.Round(2 * Mathf.PI * Mathf.Sin(theta) / d_phi);
            for (int n = 0; n < m_phi; n++)
            {
                float phi = 2 * Mathf.PI * n / m_phi;
                Vector3 delta = new Vector3(Mathf.Sin(theta) * Mathf.Cos(phi), Mathf.Sin(theta) * Mathf.Sin(phi), Mathf.Cos(theta));
                delta *= radius;
                GameObject new_orb_part = (GameObject)Instantiate(partPrefab, transform.position + delta, Quaternion.identity);

                new_orb_part.GetComponent<OrbitRock>().speed *= direction;
            }
        }

        return;
    }
}
