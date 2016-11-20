using UnityEngine;
using System.Collections;

public class MatrixMode : MonoBehaviour {

    public string[] slowMoTags;
    public float minProximity = 5.0f;
    public float slowdown = 0.1f;
    public bool isSlowMo
    {
        get
        {
            foreach(string curTag in slowMoTags)
            {
                foreach(GameObject go in GameObject.FindGameObjectsWithTag(curTag))
                {
                    if(Vector3.Distance(go.transform.position, transform.position) <= minProximity && Vector3.Dot(go.transform.forward, transform.position - go.transform.position) > 0)
                    {
                        return true;
                    } 
                }
            }
            return false;
        }
    }
	
	// Update is called once per frame
	void Update () {
 
         if (isSlowMo)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, slowdown, 0.3f);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
