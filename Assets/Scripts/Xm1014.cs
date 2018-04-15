using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xm1014 : Gun {
    public override void AIShoot()
    {
        GetComponent<Xm1014>().AttackTime -= Time.deltaTime;
        if (GetComponent<Xm1014>().MaxShoot > 0)
        {
            if (GetComponent<Xm1014>().AttackTime <= 0)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Xm1014>().AttackTime = 1.4f;
                GameObject clone = Instantiate(GetComponent<Xm1014>().ShootObj, GetComponent<Xm1014>().ShootPos.position, GetComponent<Xm1014>().ShootPos.rotation);
                clone.name = "xm1014Buttle";
                GetComponent<Xm1014>().MaxShoot--;
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
        GetComponent<Xm1014>().AttackTime -= Time.deltaTime;
        if(GetComponent<Xm1014>().MaxShoot>0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Xm1014>().AttackTime <= 0)
                {
                    GetComponent<AudioSource>().Play();
                    GetComponent<Xm1014>().AttackTime = 1.4f;
                    GameObject clone = Instantiate(GetComponent<Xm1014>().ShootObj, GetComponent<Xm1014>().ShootPos.position, GetComponent<Xm1014>().ShootPos.rotation);
                    clone.name = "xm1014Buttle";
                    GetComponent<Xm1014>().MaxShoot--;
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
    public void Init()
    {

        GetComponent<Xm1014>().MaxShoot = 60;
        GetComponent<Xm1014>().AttackForce = 30;
        GetComponent<Xm1014>().AttackTime = 1.4f;
        GetComponent<Xm1014>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
        GetComponent<Xm1014>().ID = 7;
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
}
