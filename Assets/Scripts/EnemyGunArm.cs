using UnityEngine;
using System.Collections;

public class EnemyGunArm : MonoBehaviour {
    private Transform player;
    public GameObject bulletPrefab;
    public CooldownTimer shootTimer;
    private Rigidbody playerRoot;

    public float range = 100;

    public AudioClip[] gunSounds;

    void Start()
    {
        player = FindObjectOfType<SteamVR_Camera>().transform;
        playerRoot = player.root.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (shootTimer.Use)
        {
            AudioSource.PlayClipAtPoint(gunSounds[Random.Range(0, gunSounds.Length)], transform.position);
            Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(-transform.right, Vector3.up));
        }
    }

	void LateUpdate()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        float s = Mathf.Abs(bulletPrefab.GetComponent<Train>().speed);

        float t = dist / s;

        Vector3 off = playerRoot.velocity * t;
        transform.right = -(player.position + off) + transform.position;
    }
}
