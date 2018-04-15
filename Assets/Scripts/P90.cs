using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P90 : Gun {
    public override void AIShoot()
    {
        GetComponent<P90>().AttackTime -= Time.deltaTime;
        if (GetComponent<P90>().MaxShoot > 0)
        {
            if (GetComponent<P90>().AttackTime <= 0)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<P90>().AttackTime = 0.4f;
                //Debug.Log("ok");
                GameObject clone = Instantiate(GetComponent<P90>().ShootObj, GetComponent<P90>().ShootPos.position, GetComponent<P90>().ShootPos.rotation);
                clone.name = "p90Buttle";
                GetComponent<P90>().MaxShoot--;
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
        GetComponent<P90>().AttackTime -= Time.deltaTime;
        if(GetComponent<P90>().MaxShoot>0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<P90>().AttackTime <= 0)
                {
                    GetComponent<AudioSource>().Play();
                    GetComponent<P90>().AttackTime = 0.4f;
                    //Debug.Log("ok");
                    GameObject clone = Instantiate(GetComponent<P90>().ShootObj, GetComponent<P90>().ShootPos.position, GetComponent<P90>().ShootPos.rotation);
                    clone.name = "p90Buttle";
                    GetComponent<P90>().MaxShoot--;
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

        GetComponent<P90>().MaxShoot = 200;
        GetComponent<P90>().AttackForce = 9;
        GetComponent<P90>().AttackTime = 0.4f;
        GetComponent<P90>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
        GetComponent<P90>().ID = 8;
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
}
