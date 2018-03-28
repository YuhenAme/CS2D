using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp5 : Gun {

    /// <summary>
    /// AI的射击方法
    /// </summary>
    public override void AIShoot()
    {
        GetComponent<Mp5>().AttackTime -= Time.deltaTime;
        if (GetComponent<Mp5>().MaxShoot > 0)
        {
            
            if (GetComponent<Mp5>().AttackTime <= 0)
            {
                GetComponent<Mp5>().AttackTime = 0.4f;
                GameObject clone = Instantiate(GetComponent<Mp5>().ShootObj, GetComponent<Mp5>().ShootPos.position, GetComponent<Mp5>().ShootPos.rotation);
                clone.name = "mp5Buttle";
                GetComponent<Mp5>().MaxShoot--;
            }
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Mp5>().AttackTime -= Time.deltaTime;
        if(GetComponent<Mp5>().MaxShoot>0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Mp5>().AttackTime <= 0)
                {
                    GetComponent<Mp5>().AttackTime = 0.4f;
                    GameObject clone = Instantiate(GetComponent<Mp5>().ShootObj, GetComponent<Mp5>().ShootPos.position, GetComponent<Mp5>().ShootPos.rotation);
                    clone.name = "mp5Buttle";
                    GetComponent<Mp5>().MaxShoot--;
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

        GetComponent<Mp5>().MaxShoot = 200;
        GetComponent<Mp5>().AttackForce = 9;
        GetComponent<Mp5>().AttackTime = 0.4f;
        GetComponent<Mp5>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	
}
