using UnityEngine;
using System.Collections;

public class ArrowBase : MonoBehaviour {

    public Vector3 forwardVector;

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Enemy>())
        {
            OnEnemyHit(col.gameObject);
        }
    }

    protected virtual void OnEnemyHit(GameObject go)
    {

    }
    
 
}
