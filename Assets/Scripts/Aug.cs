﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aug : Gun {


    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Aug>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Aug>().AttackTime <= 0)
            {
                GetComponent<Aug>().AttackTime = 0.7f;
                Debug.Log("ok");
            }
        }
    }


    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {
        
        GetComponent<Aug>().MaxShoot = 150;
        GetComponent<Aug>().AttackForce = 15;
        GetComponent<Aug>().AttackTime = 0.7f;
        GetComponent<Aug>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	
}