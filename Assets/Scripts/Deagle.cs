using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deagle : Gun {
    public override void Shoot()
    {
        GetComponent<Deagle>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Deagle>().AttackTime <= 0)
            {
                GetComponent<Deagle>().AttackTime = 1.0f;
                Debug.Log("done");
            }
        }
    }


    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {
        GetComponent<Deagle>().MaxShoot = 40;
        GetComponent<Deagle>().AttackForce = 9;
        GetComponent<Deagle>().AttackTime = 1.0f;
        GetComponent<Deagle>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
