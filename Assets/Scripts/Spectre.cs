using UnityEngine;
using System.Collections;

public class Spectre : MonoBehaviour {
    public GameObject spectrePrefab;

    private Bow bow;
    private GameObject spectre;
    new private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        spectre = Instantiate(spectrePrefab);
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {
        Destroy(spectre);
    }
	
	// Update is called once per frame
	void Update ()
    {
        bow = FindObjectOfType<Bow>();
        if (bow.nocked)
        {
            spectre.SetActive(true);

            float d = Vector3.Distance(transform.position, bow.transform.position);
            float v = bow.NockedPotentialVelocity();
            float t = d / v;

            spectre.transform.position = transform.position + rigidbody.velocity * t;
            spectre.transform.rotation = transform.rotation;

            float f = v / bow.maxVelocity;
            f = f * f * f * f * f * f *f;
            foreach (SkinnedMeshRenderer mesh in spectre.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                mesh.material.color = new Color(0, 0, 0, f / 2);
            }
        } else
        {
            spectre.SetActive(false);
        }
	}
}
