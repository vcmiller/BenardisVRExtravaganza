using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckPlayerReady : MonoBehaviour {

    public string sceneName;
    ReadyIndicator[] ris;

	// Use this for initialization
	void Start () {
        ris = GetComponentsInChildren<ReadyIndicator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool isReady = true;
        foreach(ReadyIndicator ri in ris)
        {
            if (!ri.isReady)
            {
                isReady = false;
            }
        }

        if (isReady)
        {
            SceneManager.LoadScene(sceneName);
        }
	}
}
