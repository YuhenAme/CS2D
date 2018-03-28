using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有枪械的父类
/// </summary>
public abstract class Gun : MonoBehaviour {

    //属性---------------------
    /// <summary>
    /// 武器的攻击力
    /// </summary>
    [SerializeField]
    protected int attackForce;
    public int AttackForce
    {
        get
        {
           return attackForce;
        }
        set
        {
            attackForce = value;
        }
    }

    /// <summary>
    /// 武器的攻击间隔时间
    /// </summary>
    [SerializeField]
    private  float attackTime;
    public float AttackTime
    {
        get
        {
            return attackTime;
        }
        set
        {
            attackTime = value;
        }
    }

    /// <summary>
    /// 武器的子弹发射位置
    /// </summary>
    [SerializeField]
    private Transform shootPos;
    public Transform ShootPos
    {
        get
        {
            return shootPos;
        }
        set
        {
            shootPos = value;
        }
    }

    /// <summary>
    /// 子弹的限制数
    /// </summary>
    [SerializeField]
    private int maxShoot;
    public int MaxShoot
    {
        get
        {
            return maxShoot;
        }
        set
        {
            maxShoot = value;
        }
    }

    /// <summary>
    /// 子弹
    /// </summary>
    [SerializeField]
    private GameObject shootObj;
    public GameObject ShootObj
    {
        get
        {
            return shootObj;
        }
        set
        {
            shootObj = value;
        }
    }



    //方法---------------------
    /// <summary>
    /// 射击方法
    /// </summary>
    /// <param name="attacktime">射击具体的间隔时间</param>
    public abstract void Shoot();

    /// <summary>
    /// AI的射击方法
    /// </summary>
    public abstract void AIShoot();



void Start()
    {
        //shootPos = GameObject.Find("shootPos").transform;
    }




}
