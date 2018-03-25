using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControll : MonoBehaviour {

    //属性------------------
    /// <summary>
    /// 人物的贴图
    /// </summary>
    [SerializeField]
    private Sprite humanSprite;

    /// <summary>
    /// 人物自身血量
    /// </summary>
    [SerializeField]
    private int hp=100;

    /// <summary>
    /// 人物的移动速度
    /// </summary>
    [SerializeField]
    private float moveSpeed=1.0f;

    /// <summary>
    /// 人物所需刚体
    /// </summary>
    private Rigidbody2D playerRigid;

    /// <summary>
    /// 枪的枚举类型
    /// </summary>
    private enum GunType
    {
        ak47,
        aug,
        deagle,
        famas,
        galil,
        mp5,
        p90,
        scout,
        xm1014,
        usp
    }

    /// <summary>
    /// 当前枪械状态
    /// </summary>
    [SerializeField]
    private GunType gunType;

    /// <summary>
    /// 人物的攻击力
    /// </summary>
    private int attackForce;

    /// <summary>
    /// 人物的攻击间隔
    /// </summary>
    private float attackTime;
    




    //方法------------------
    /// <summary>
    /// 改变朝向，一直面向鼠标位置
    /// </summary>
    private void LookTo()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量 
        direction = direction.normalized;
        //用于限制角度()  
        //物体自身的Y轴和目标向量保持一致
        transform.up = direction;
    }
    /// <summary>
    /// 人物移动
    /// </summary>
    private void Move(){
        //水平轴移动
        float h = Input.GetAxisRaw("Horizontal");
        //竖直轴移动
        float v = Input.GetAxisRaw("Vertical");
        playerRigid.velocity = new Vector2(h, v).normalized * moveSpeed;

    }
    /// <summary>
    /// 人物受伤
    /// </summary>
    private void Hurt()
    {
        //受到伤害
        if (hp <= 0)
        {
            //人物死亡
        }
       
    }
    /// <summary>
    /// 人物攻击
    /// </summary>
    private void Attack()
    {
            //实例化子弹
            //根据枪械的种类来调用对应枪的shoot()方法
            switch (gunType)
            {
                case GunType.ak47:
                    GameObject.Find("ak47").GetComponent<Ak47>().Shoot();
                    break;
                case GunType.aug:
                    GameObject.Find("aug").GetComponent<Aug>().Shoot();
                    break;
                case GunType.deagle:
                    GameObject.Find("deagle").GetComponent<Deagle>().Shoot();
                    break;
                case GunType.famas:
                    Debug.Log("OK");
                    break;
                case GunType.galil:
                    Debug.Log("OK");
                    break;
            }
        
    }

    /// <summary>
    /// 更改玩家所持枪械状态
    /// </summary>
    private void ChangeState(GunType g)
    {
        if (gunType != g)
        {
            gunType = g;
        }
        else
        {
            return;
        }
    }


    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = humanSprite;
        gunType = GunType.ak47;
	}
	
	// Update is called once per frame
	void Update () {
        LookTo();
        Move();
        Hurt();
        Attack();
    }

}
