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
    /// 人物死亡的贴图
    /// </summary>
    [SerializeField]
    private Sprite diedSprite;

    /// <summary>
    /// 人物是否存活的状态
    /// </summary>
    [SerializeField]
    private bool isAlive;

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
    private static GunType gunType;

    




    //方法------------------
    /// <summary>
    /// 改变朝向，一直面向鼠标位置
    /// </summary>
    private void LookTo()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一致  
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
    private void Hurt(GunType gunBullet)
    {
        //受到伤害
        //Debug.Log(gunBullet.ToString());
        switch (gunBullet)
        {
            case GunType.ak47://Debug.Log(gunBullet.ToString());
                hp -= 15;
                break;
            case GunType.aug:
                hp -= 15;
                break;
            case GunType.deagle:
                hp -= 9;
                break;
            case GunType.famas:
                hp -= 25;
                break;
            case GunType.galil:
                hp -= 25;
                break;
            case GunType.mp5:
                hp -= 10;
                break;
            case GunType.p90:
                hp -= 9;
                break;
            case GunType.scout:
                hp -= 35;
                break;
            case GunType.usp:
                hp -= 9;
                break;
            case GunType.xm1014:
                hp -= 30;
                break;
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
                    GameObject.Find("famas").GetComponent<Famas>().Shoot();
                    break;
                case GunType.galil:
                    GameObject.Find("galil").GetComponent<Galil>().Shoot();
                    break;
                case GunType.mp5:
                    GameObject.Find("mp5").GetComponent<Mp5>().Shoot();
                    break;
                case GunType.p90:
                    GameObject.Find("p90").GetComponent<P90>().Shoot();
                    break;
                case GunType.scout:
                    GameObject.Find("scout").GetComponent<Scout>().Shoot();
                    break;
                case GunType.usp:
                    GameObject.Find("usp").GetComponent<Usp>().Shoot();
                    break;
                case GunType.xm1014:
                    GameObject.Find("xm1014").GetComponent<Xm1014>().Shoot();
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
            GameObject.Find(gunType.ToString()).SetActive(false);
            gunType = g;
            //找到对应的子物体并将其置为可见
            //Debug.Log(gunType.ToString());
            this.gameObject.transform.Find(gunType.ToString()).gameObject.SetActive(true);

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
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp> 0)
        {
            LookTo();
            Move();
            Attack();
        }
        else
        {
            //人物死亡
            isAlive = false;
            //更换人物的贴图为死亡贴图
            GetComponent<SpriteRenderer>().sprite = diedSprite;
            //将子物体置为不可见
            this.gameObject.transform.Find(gunType.ToString()).gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// 玩家更换枪械，受到伤害等的碰撞检测
    /// </summary>
    /// <param name="collision">枪的碰撞体</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //与子弹发生碰撞
        //子弹类型
        GunType gunbullet;
        //与子弹发生碰撞
        for (gunbullet = GunType.ak47; gunbullet <= GunType.usp; gunbullet++)
        {
            //Debug.Log("d");
            if (gunbullet.ToString() + "Buttle" == collision.gameObject.name)
            {
                break;
            }
        }
        Hurt(gunbullet);


        //与枪械发生碰撞(更换枪械)
        if (gunType.ToString() + "_d" != collision.gameObject.name)
        {
            GunType t;
            for (t = GunType.ak47; t <= GunType.usp; t++)
            {
                if (t.ToString() + "_d" == collision.gameObject.name)
                {
                    break;//如果没有找到则t结束循环时t会等于10
                }
            }
            //如果未检测到相应的枪械的碰撞体则不改变枪的状态
            if (t > GunType.usp)
            {
                t = gunType;
            }
            //Debug.Log(t.ToString());
            ChangeState(t);
        }
    }


   



}
