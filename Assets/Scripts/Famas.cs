using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Famas : Gun {

    /// <summary>
    /// AI的射击方法
    /// </summary>
    public override void AIShoot()
    {
        GetComponent<Famas>().AttackTime -= Time.deltaTime;
        if (GetComponent<Famas>().MaxShoot > 0)
        {
            if (GetComponent<Famas>().AttackTime <= 0)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Famas>().AttackTime = 1.6f;
                //Debug.Log("done");
                GameObject clone = Instantiate(GetComponent<Famas>().ShootObj, GetComponent<Famas>().ShootPos.position, GetComponent<Famas>().ShootPos.rotation);
                clone.name = "famasButtle";
                GetComponent<Famas>().MaxShoot--;
            }
        }
        else
        {
            return;
        }
    }

    public override void Shoot()
    {
        GetComponent<Famas>().AttackTime -= Time.deltaTime;
        if (GetComponent<Famas>().MaxShoot > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Famas>().AttackTime <= 0)
                {
                    GetComponent<AudioSource>().Play();
                    GetComponent<Famas>().AttackTime = 1.6f;
                    //Debug.Log("done");
                    GameObject clone = Instantiate(GetComponent<Famas>().ShootObj, GetComponent<Famas>().ShootPos.position, GetComponent<Famas>().ShootPos.rotation);
                    clone.name = "famasButtle";
                    GetComponent<Famas>().MaxShoot--;
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
        GetComponent<Famas>().MaxShoot = 70;
        GetComponent<Famas>().AttackForce = 25;
        GetComponent<Famas>().AttackTime = 1.6f;
        GetComponent<Famas>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
        GetComponent<Famas>().ID = 3;
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
