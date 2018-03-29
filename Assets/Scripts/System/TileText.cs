using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileText : MonoBehaviour {

    private GameObject[] ct;
    private GameObject[] t;
    // Use this for initialization
    void Start () {
         //ct = GameObject.FindGameObjectsWithTag("CT");
         //t = GameObject.FindGameObjectsWithTag("T");
    }
	
	// Update is called once per frame
	void Update () {
        ct = GameObject.FindGameObjectsWithTag("CT");
        t = GameObject.FindGameObjectsWithTag("T");
        string s = ct.Length.ToString();
        string a = t.Length.ToString();
        GetComponent<Text>().text = "CT:" + s + "      VS      " + "T:" + a;

    }
}
