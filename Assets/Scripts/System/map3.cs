using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class map3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void OnDown()
    {
        //第三地图
        SceneManager.LoadScene(4);
    }
}
