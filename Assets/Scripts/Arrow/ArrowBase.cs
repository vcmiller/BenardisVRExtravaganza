﻿using UnityEngine;
using System.Collections;

public class ArrowBase : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Enemy en;
        if (en = col.transform.root.GetComponentInChildren<Enemy>())
        {
            OnEnemyHit(en);
        }

    }

    protected virtual void OnEnemyHit(Enemy en)
    {
       en.kill = true;   
    }
    
 
}
