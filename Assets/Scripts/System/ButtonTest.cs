using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Button {


    protected override void OnBottonDown()
    {
        Debug.Log("button");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
