using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp5 : Gun {

    /// <summary>
    /// 该枪械的射击方法
    /// </summary>
    public override void Shoot()
    {
        GetComponent<Mp5>().AttackTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Mp5>().AttackTime <= 0)
            {
                GetComponent<Mp5>().AttackTime = 0.4f;
                Debug.Log("ok");
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
