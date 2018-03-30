using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnDown()
    {
        SceneManager.LoadScene(0);
    }
}
