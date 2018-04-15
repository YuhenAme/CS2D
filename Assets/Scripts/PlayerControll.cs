using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControll : MonoBehaviour {

    //属性与字段------------------
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
    private bool IsAlive{get; set;}

    /// <summary>
    /// 人物自身血量
    /// </summary>
    [SerializeField]
    public int hp = 100;
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
    /// 玩家的音效
    /// </summary>
    private AudioSource[] arrAllAudioSource;


    //-------------------------------------------------------------

    /// <summary>
    /// 玩家持有的武器
    /// </summary>
    private Gun theGun;
    public Gun TheGun { get; set; }

    /// <summary>
    /// 设置武器的函数
    /// </summary>
    /// <param name="gun">传入的武器</param>
    public void SetGun(Gun gun)
    {
        //当武器不为空时，改变武器
        if (TheGun != null)
        {
            gameObject.transform.GetChild(TheGun.ID).gameObject.SetActive(false);
            TheGun = gun;
            gameObject.transform.GetChild(TheGun.ID).gameObject.SetActive(true);
            arrAllAudioSource[2].Play();
        }
        else
        {
            TheGun = gun;
            gameObject.transform.GetChild(TheGun.ID).gameObject.SetActive(true);
        }
    }

    //方法------------------
    private PlayerControll instance;
   /// <summary>
   /// 获取自身实例
   /// </summary>
    public PlayerControll Instance
    {//单例模式
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("player").GetComponent<PlayerControll>();
            }
            return instance;
        }
    }
   
    /// <summary>
    /// 初始化函数
    /// </summary>
    private void Init()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = humanSprite;
        IsAlive = true;
        //获得音效
        arrAllAudioSource = gameObject.GetComponents<AudioSource>();
        //设置武器,获得武器的实例
        Instance.SetGun(GunInstance.Ak47Instance);
        //Debug.Log(GunInstance.AugInstance.ID.ToString());
    }

    /// <summary>
    /// 处理各种碰撞
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "aug")
        {
            SetGun(GunInstance.AugInstance);
        }
        if (collision.tag == "deagle")
        {
            SetGun(GunInstance.DeagleInstance);
        }
        if (collision.tag == "famas")
        {
            SetGun(GunInstance.FamasInstance);
        }
        if (collision.tag == "galil")
        {
            SetGun(GunInstance.GalilInstance);
        }
        if (collision.tag == "mp5")
        {
            SetGun(GunInstance.Mp5Instance);
        }
        if (collision.tag == "p90")
        {
            SetGun(GunInstance.P90Instance);
        }
        if (collision.tag == "scout")
        {
            SetGun(GunInstance.ScoutInstance);
        }
        if (collision.tag == "usp")
        {
            SetGun(GunInstance.UspInstance);
        }
        if (collision.tag == "xm1014")
        {
            SetGun(GunInstance.Xm1014Instance);
        }
    }

    /// <summary>
    /// 重写玩家攻击函数
    /// </summary>
    private void PlayerAttack()
    {
        MaxShoot = TheGun.MaxShoot;
        TheGun.Shoot();
    }

    //武器接口重构完成，这样买枪的话直接SetGun()就可以实现了-----------
    //等待重构(重写)玩家的伤害判断，准备写一个系统类包含伤害判断等-----



    //------------------------------------------------
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

    
    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = humanSprite;
        //gunType = GunType.ak47;
        isAlive = true;
        arrAllAudioSource = gameObject.GetComponents<AudioSource>();
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        getMenu();
        if (hp> 0)
        {
            LookTo();
            Move();
            PlayerAttack();
            
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

}
