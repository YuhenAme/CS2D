using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P90 : Gun {

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<P90>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<P90>().AttackTime <= 0)
            {
                GetComponent<P90>().AttackTime = 0.4f;
                Debug.Log("ok");
            }
        }
    }
    /// <summary>
    /// 初始化方法
    /// </summary>    
    private void Init()
    {

        GetComponent<P90>().MaxShoot = 200;
        GetComponent<P90>().AttackForce = 9;
        GetComponent<P90>().AttackTime = 0.4f;
        GetComponent<P90>().ShootPos = GetComponentInChildren<Transform>().Find("shootPosition");
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
}
