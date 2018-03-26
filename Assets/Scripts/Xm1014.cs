using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xm1014 : Gun {

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Xm1014>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Xm1014>().AttackTime <= 0)
            {
                GetComponent<Xm1014>().AttackTime = 1.4f;
                Debug.Log("ok");
            }
        }
    }
    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {

        GetComponent<Xm1014>().MaxShoot = 60;
        GetComponent<Xm1014>().AttackForce = 30;
        GetComponent<Xm1014>().AttackTime = 1.4f;
        GetComponent<Xm1014>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
}
