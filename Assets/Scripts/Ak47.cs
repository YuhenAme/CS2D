using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Gun {



    /// <summary>
    /// AI的射击方法
    /// </summary>
    public override void AIShoot()
    {
        GetComponent<Ak47>().AttackTime -= Time.deltaTime;
        if (GetComponent<Ak47>().MaxShoot > 0)
        {
            if (GetComponent<Ak47>().AttackTime <= 0)
            {
                //添加音效
                GetComponent<AudioSource>().Play();
                GetComponent<Ak47>().AttackTime = 1.6f;
                GameObject clone = Instantiate(GetComponent<Ak47>().ShootObj, GetComponent<Ak47>().ShootPos.position, GetComponent<Ak47>().ShootPos.rotation);
                clone.name = "ak47Buttle";
                GetComponent<Ak47>().MaxShoot--;
            }
        }
        else
        {
            return;
        }
    }

    //private Rigidbody2D cloneRigid;
    public override void Shoot()
    {
        GetComponent<Ak47>().AttackTime -= Time.deltaTime;
        if (GetComponent<Ak47>().MaxShoot > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Ak47>().AttackTime <= 0)
                {
                    //添加音效
                    GetComponent<AudioSource>().Play();
                    GetComponent<Ak47>().AttackTime = 0.6f;
                    GameObject clone = Instantiate(GetComponent<Ak47>().ShootObj, GetComponent<Ak47>().ShootPos.position, GetComponent<Ak47>().ShootPos.rotation);
                    clone.name = "ak47Buttle";
                    GetComponent<Ak47>().MaxShoot--;
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
        GetComponent<Ak47>().MaxShoot = 100;
        GetComponent<Ak47>().AttackForce = 15;
        GetComponent<Ak47>().AttackTime = 0.6f;
        GetComponent<Ak47>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
   
    // Use this for initialization
    void Start () {
       
        Init();
        //float a = GetComponent<Ak47>().AttackTime;
    }
	
	
   
}
