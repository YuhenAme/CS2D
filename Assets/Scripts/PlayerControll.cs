using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private static bool isAlive;

    /// <summary>
    /// 人物自身血量
    /// </summary>
    [SerializeField]
    public int hp=100;

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
    public enum GunType
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
    public  GunType gunType;

    /// <summary>
    /// 当前弹药数
    /// </summary>
    public int maxShoot;

    /// <summary>
    /// 玩家的音效
    /// </summary>
    private AudioSource[] arrAllAudioSource;

    /// <summary>
    /// 是否处于购买的状态
    /// </summary>
    [SerializeField]
    private bool isBuying = false;

    public bool IsBuying
    {
        set
        {
            isBuying = value;
        }
    }

    public GameObject panel;

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
                hp -= 15; arrAllAudioSource[1].Play();
                break;
            case GunType.aug:
                hp -= 15; arrAllAudioSource[1].Play();
                break;
            case GunType.deagle:
                hp -= 9; arrAllAudioSource[1].Play();
                break;
            case GunType.famas:
                hp -= 25; arrAllAudioSource[1].Play();
                break;
            case GunType.galil:
                hp -= 25; arrAllAudioSource[1].Play();
                break;
            case GunType.mp5:
                hp -= 10; arrAllAudioSource[1].Play();
                break;
            case GunType.p90:
                hp -= 9; arrAllAudioSource[1].Play();
                break;
            case GunType.scout:
                hp -= 35; arrAllAudioSource[1].Play();
                break;
            case GunType.usp:
                hp -= 9; arrAllAudioSource[1].Play();
                break;
            case GunType.xm1014:
                hp -= 30; arrAllAudioSource[1].Play();
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
                    gameObject.transform.Find("ak47").GetComponent<Ak47>().Shoot();
                    maxShoot = gameObject.transform.Find("ak47").GetComponent<Ak47>().MaxShoot;
                    break;
                case GunType.aug:
                    gameObject.transform.Find("aug").GetComponent<Aug>().Shoot();
                    maxShoot = gameObject.transform.Find("aug").GetComponent<Aug>().MaxShoot;
                    break;
                case GunType.deagle:
                    gameObject.transform.Find("deagle").GetComponent<Deagle>().Shoot();
                    maxShoot = gameObject.transform.Find("deagle").GetComponent<Deagle>().MaxShoot;
                    break;
                case GunType.famas:
                    gameObject.transform.Find("famas").GetComponent<Famas>().Shoot();
                    maxShoot = gameObject.transform.Find("famas").GetComponent<Famas>().MaxShoot;
                    break;
                case GunType.galil:
                    gameObject.transform.Find("galil").GetComponent<Galil>().Shoot();
                    maxShoot = gameObject.transform.Find("galil").GetComponent<Galil>().MaxShoot;
                    break;
                case GunType.mp5:
                    gameObject.transform.Find("mp5").GetComponent<Mp5>().Shoot();
                    maxShoot = gameObject.transform.Find("mp5").GetComponent<Mp5>().MaxShoot;
                    break;
                case GunType.p90:
                    gameObject.transform.Find("p90").GetComponent<P90>().Shoot();
                    maxShoot = gameObject.transform.Find("p90").GetComponent<P90>().MaxShoot;
                    break;
                case GunType.scout:
                    gameObject.transform.Find("scout").GetComponent<Scout>().Shoot();
                    maxShoot = gameObject.transform.Find("scout").GetComponent<Scout>().MaxShoot;
                    break;
                case GunType.usp:
                    gameObject.transform.Find("usp").GetComponent<Usp>().Shoot();
                    maxShoot = gameObject.transform.Find("usp").GetComponent<Usp>().MaxShoot;
                    break;
                case GunType.xm1014:
                    gameObject.transform.Find("xm1014").GetComponent<Xm1014>().Shoot();
                    maxShoot = gameObject.transform.Find("xm1014").GetComponent<Xm1014>().MaxShoot;
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
            gameObject.transform.Find(gunType.ToString()).gameObject.SetActive(false);
            gunType = g;
            //找到对应的子物体并将其置为可见
            this.gameObject.transform.Find(gunType.ToString()).gameObject.SetActive(true);
            arrAllAudioSource[2].Play();

        }
        else
        {
            return;
        }

    }

    /// <summary>
    /// 调出主菜单
    /// </summary>
    private void getMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            return;
        }

        
    }

    

    /// <summary>
    /// 购买枪械的ui
    /// </summary>
    private void BuyGuns()
    {
        //GameObject BuyGunsPanel = GameObject.Find("minimap").transform.Find("BuyGunPanel").gameObject;
        panel.SetActive(true);
        isBuying = true;

    }

    /// <summary>
    /// 玩家的行动，包括移动，攻击，买枪等
    /// </summary>
    private void Act()
    {
        if (isBuying == false)
        {
            LookTo();
            Move();
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuyGuns();
        }

    }



    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = humanSprite;
        gunType = GunType.ak47;
        isAlive = true;
        arrAllAudioSource = gameObject.GetComponents<AudioSource>();
        panel = GameObject.Find("minimap").transform.Find("BuyGunPanel").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        getMenu();
        if (hp> 0)
        {
            //LookTo();
            //Move();
            //Attack();
            Act();
            
        }
        else
        {
            this.tag = "Died";
            playerRigid.velocity = new Vector2(0, 0);
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
