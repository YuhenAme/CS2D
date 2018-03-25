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

    /// <summary>
    /// 武器的攻击间隔时间
    /// </summary>
    [SerializeField]
    private  float attackTime;

    /// <summary>
    /// 对应的武器贴图
    /// </summary>
    [SerializeField]
    private Sprite gunSprite;

    /// <summary>
    /// 武器的子弹发射位置
    /// </summary>
    [SerializeField]
    private Transform shootPos;

    /// <summary>
    /// 子弹的限制数
    /// </summary>
    [SerializeField]
    private int maxShoot;

    /// <summary>
    /// 子弹
    /// </summary>
    [SerializeField]
    private GameObject shootObj;


    //方法---------------------
    /// <summary>
    /// 射击方法
    /// </summary>
    /// <param name="attacktime">射击具体的间隔时间</param>
    protected  void Shoot(float time)
    {
        time = attackTime;
        //GameObject clone = Instantiate(shoot, shootPos.position, shootPos.rotation);
        //Rigidbody2D cloneRigid = clone.GetComponent<Rigidbody2D>();
        //设置攻击间隔
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            attackTime = time;
            GameObject clone = Instantiate(shootObj, shootPos.position, shootPos.rotation);
            Rigidbody2D cloneRigid = clone.GetComponent<Rigidbody2D>();
           //设置子弹的速度
            cloneRigid.velocity = transform.TransformDirection(Vector3.forward* 10);
        }

    }


    public void SetAttackForce(int aF)
    {
        attackForce = aF;
    }
    public void SetAttackTime(float aT)
    {
        attackTime = aT;
    }
    public void SetGunSprite(Sprite gunS)
    {
        gunSprite = gunS;
    }
    public void SetShootPos(Transform shootP)
    {
        shootPos = shootP;
    }
    public void SetMaxShoot(int max)
    {
        maxShoot = max;
    }
    public void SetShootObj(GameObject shoot)
    {
        shootObj = shoot;
    }

    void Start()
    {
        shootPos = GameObject.Find("shootPos").transform;
    }




}
