using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usp : Gun {

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Usp>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Usp>().AttackTime <= 0)
            {
                GetComponent<Usp>().AttackTime = 1.0f;
                Debug.Log("ok");
            }
        }
    }
    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {

        GetComponent<Usp>().MaxShoot = 40;
        GetComponent<Usp>().AttackForce = 9;
        GetComponent<Usp>().AttackTime = 1.0f;
        GetComponent<Usp>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
}
