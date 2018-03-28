using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Gun {
    public override void AIShoot()
    {
        GetComponent<Scout>().AttackTime -= Time.deltaTime;
        if (GetComponent<Scout>().MaxShoot > 0)
        {
            if (GetComponent<Scout>().AttackTime <= 0)
            {
                GetComponent<Scout>().AttackTime = 1.7f;
                GameObject clone = Instantiate(GetComponent<Scout>().ShootObj, GetComponent<Scout>().ShootPos.position, GetComponent<Scout>().ShootPos.rotation);
                clone.name = "scoutButtle";
                GetComponent<Scout>().MaxShoot--;
            }
            else
            {
                return;
            }
        }
            
    }

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Scout>().AttackTime -= Time.deltaTime;
        if(GetComponent<Scout>().MaxShoot>0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Scout>().AttackTime <= 0)
                {
                    GetComponent<Scout>().AttackTime = 1.7f;
                    GameObject clone = Instantiate(GetComponent<Scout>().ShootObj, GetComponent<Scout>().ShootPos.position, GetComponent<Scout>().ShootPos.rotation);
                    clone.name = "scoutButtle";
                    GetComponent<Scout>().MaxShoot--;
                }
            }
            else
            {
                return;
            }
        }
    }
    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {

        GetComponent<Scout>().MaxShoot = 70;
        GetComponent<Scout>().AttackForce = 35;
        GetComponent<Scout>().AttackTime = 1.7f;
        GetComponent<Scout>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	
}
