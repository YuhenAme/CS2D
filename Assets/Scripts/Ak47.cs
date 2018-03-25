using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Gun {

    public override void Shoot()
    {
        GetComponent<Ak47>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Ak47>().AttackTime <= 0)
            {
                GetComponent<Ak47>().AttackTime = 0.6f;
                Debug.Log("done");
            }
        }
    }

    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {
        GetComponent<Ak47>().MaxShoot = 100;
        GetComponent<Ak47>().AttackForce = 15;
        GetComponent<Ak47>().AttackTime = 0.6f;
        GetComponent<Ak47>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
   
    // Use this for initialization
    void Start () {
        Init();
        float a = GetComponent<Ak47>().AttackTime;
    }
	
	// Update is called once per frame
	//void Update () {
        
	//}
   
}
