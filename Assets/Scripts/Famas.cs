using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Famas : Gun {


    public override void Shoot()
    {
        GetComponent<Famas>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Famas>().AttackTime <= 0)
            {
                GetComponent<Famas>().AttackTime = 1.6f;
                Debug.Log("done");
            }
        }
    }

    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {
        GetComponent<Famas>().MaxShoot = 70;
        GetComponent<Famas>().AttackForce = 25;
        GetComponent<Famas>().AttackTime = 1.6f;
        GetComponent<Famas>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
