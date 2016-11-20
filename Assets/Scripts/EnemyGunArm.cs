using UnityEngine;
using System.Collections;

public class EnemyGunArm : MonoBehaviour {
    private Transform player;
    public GameObject bulletPrefab;
    public CooldownTimer shootTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (shootTimer.Use)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(-transform.right, Vector3.up));
        }
    }

	void LateUpdate()
    {
        transform.right = -player.position + transform.position;
    }
}
