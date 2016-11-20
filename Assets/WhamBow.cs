using UnityEngine;
using System.Collections;

public class WhamBow : MonoBehaviour {

    public AudioClip[] hitSounds;

    void OnTriggerEnter(Collider col)
    {
        Enemy en;
        if (en = col.transform.root.GetComponentInChildren<Enemy>())
        {
            OnEnemyHit(en);
        }else if (col.transform.root.GetComponentInChildren<RagdollGib>())
        {
            print("I MISS THE OLD GENJI " + col.name);
        }

    }

    protected virtual void OnEnemyHit(Enemy en)
    {
        AudioSource.PlayClipAtPoint(hitSounds[Random.Range(0, hitSounds.Length)], transform.position);
        en.kill = true;
    }

}
