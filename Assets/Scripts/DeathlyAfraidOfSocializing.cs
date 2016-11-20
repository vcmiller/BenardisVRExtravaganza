using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathlyAfraidOfSocializing : MonoBehaviour {

    static int socialLimits = 20;

	// Use this for initialization
	void Start () {
        DeathlyAfraidOfSocializing[] skellies;
	    if((skellies = FindObjectsOfType<DeathlyAfraidOfSocializing>()).Length > socialLimits)
        {
            Vector3 playerPos = FindObjectOfType<SteamVR_Camera>().transform.position;
            DeathlyAfraidOfSocializing tooSpooked = this;
            foreach (DeathlyAfraidOfSocializing skelly in skellies)
            {
                if (Vector3.Distance(playerPos, skelly.transform.position) > Vector3.Distance(tooSpooked.transform.position, playerPos)) { 
                    tooSpooked = skelly;
                }
            }
            Destroy(tooSpooked);
        }
	}
	
	// Update is called once per frame
}
