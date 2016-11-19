using UnityEngine;
using System.Collections;

public class ArrowBase : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Enemy"))
        {
            OnEnemyHit(col.gameObject);
        }
    }

    protected virtual void OnEnemyHit(GameObject go)
    {

    }
    
 
}
