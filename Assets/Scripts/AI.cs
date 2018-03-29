using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class AI : MonoBehaviour {

    //属性--------------------------
    /// <summary>
    /// AI的刚体
    /// </summary>
    [SerializeField]
    private Rigidbody2D aiRigid;

    /// <summary>
    /// AI的血量
    /// </summary>
    [SerializeField]
    private int hp = 100;

    /// <summary>
    /// AI的贴图
    /// </summary>
    [SerializeField]
    private Sprite aiSprite;

    /// <summary>
    /// AI是否存活的状态
    /// </summary>
    [SerializeField]
    private bool isAlive;

    /// <summary>
    /// 人物的移动速度
    /// </summary>
    [SerializeField]
    private float moveSpeed = 1.0f;

    /// <summary>
    /// 枪的枚举类型
    /// </summary>
    [SerializeField]
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

    /// <summary>
    /// AI的状态枚举
    /// </summary>
    [SerializeField]
    private enum State
    {
        move,
        rotate,
        shoot,
    }

    /// <summary>
    /// 记录敌人上一次思考时间
    /// </summary>
    [SerializeField]
    private float aiThinkLastTime;

    /// <summary>
    /// 当前的状态
    /// </summary>
    [SerializeField]
    private State state;

    /// <summary>
    /// 死亡的贴图
    /// </summary>
    [SerializeField]
    private Sprite diedSprite;



    //方法-------------------------
    /// <summary>
    /// 更新AI
    /// </summary>
    private void UpdateAI()
    {
        if (IsThink())
        {
            //Debug.Log("思考");
            //敌人开始思考
            AIthinkState(2);
        }
        else
        {
            //Debug.Log("更新状态");
            UpdateAIState();

        }
    }

    /// <summary>
    /// 生成随机数
    /// </summary>
    /// <param name="count">随机数参数</param>
    /// <returns></returns>
    int getRandom(int count)
    {
        return new System.Random().Next(count);
    }


    /// <summary>
    /// AI进行思考，根据随机数更改状态
    /// </summary>
    /// <param name="v"></param>
    private void AIthinkState(int v)
    {
        //开始随机数字。
        int d = getRandom(v);
        switch (d)
        {
            case 0:
                //Debug.Log("状态1,移动");
                setAIState(State.move);
                break;
            case 1:
                //Debug.Log("状态2，转向");
                setAIState(State.rotate);
                break;
        }
    }

    /// <summary>
    /// 判断并更改当前的状态
    /// </summary>
    /// <param name="newState">新的状态</param>
    private void setAIState(State newState)
    {
        if (state == newState)
            return;
        state = newState;
    }

    /// <summary>
    /// 记录AI是否进行思考
    /// </summary>
    /// <returns></returns>
    private bool IsThink()
    {
        
        //这里表示敌人每2秒进行一次思考
        if (Time.time - aiThinkLastTime >= 2.0f)
        {
            //Debug.Log("done");
            aiThinkLastTime = Time.time;
            return true;

        }
        return false;
    }

    /// <summary>
    /// 更新AI的行为状态
    /// </summary>
    private void UpdateAIState()
    {
        //攻击判断,如果处于可以进行攻击的状态，则攻击状态优先
        //T找CT
        //CT找T
        if (tag == "CT")
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("T");
            foreach (GameObject go in gos)
            {
                //判断敌人与主角之间的距离
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= 2)
                {
                    //使Enemy朝向目标
                    Vector3 goPos = go.transform.position;
                    Vector3 obj = transform.position;
                    Vector3 direction = goPos - obj;
                    direction.z = 0f;
                    direction = direction.normalized;
                    transform.up = direction;

                    setAIState(State.shoot);
                }

            }
        }else if (tag == "T")
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("CT");
            foreach (GameObject go in gos)
            {
                //判断敌人与主角之间的距离
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= 2)
                {
                    //使Enemy朝向目标
                    Vector3 goPos = go.transform.position;
                    Vector3 obj = transform.position;
                    Vector3 direction = goPos - obj;
                    direction.z = 0f;
                    direction = direction.normalized;
                    transform.up = direction;

                    setAIState(State.shoot);
                }

            }
        }

            switch (state)
        {
            case State.move:
                //Debug.Log("move");
                Move();
                break;
            case State.rotate:
                //Debug.Log("rotate");
                Rotate();
                break;
            case State.shoot:
                //Debug.Log("shoot");
                Shoot();
                break;
            
        }
    }


    /// <summary>
    /// 移动方法
    /// </summary>
    private void Move()
    {
        //Debug.Log("move");
        aiRigid.velocity= transform.TransformDirection(Vector3.up * 0.5f);
    }
    /// <summary>
    /// 转向方法
    /// </summary>
    private void Rotate()
    {
        //Debug.Log("rotate");
        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime);
    }
    
    /// <summary>
    /// 攻击方法
    /// </summary>
    private void Shoot()
    {
       // Debug.Log("shoot");
        //transform.LookAt()

        gameObject.transform.Find("ak47").GetComponent<Ak47>().AIShoot();
        //GameObject.Find("ak470").GetComponent<Ak47>().AIShoot();
           
        
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
            case GunType.ak47:
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


    // Use this for initialization
    void Start () {
        aiRigid = GetComponent<Rigidbody2D>();
        gunType = GunType.ak47;
        hp = 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (hp > 0)
        {
            UpdateAI();
        }
        else
        {
            //Debug.Log("over");
            aiRigid.velocity = new Vector2(0,0);
            this.tag = "Died";
            GetComponent<SpriteRenderer>().sprite = diedSprite;
            this.gameObject.transform.Find("ak47").gameObject.SetActive(false);
        }
        
    }

    /// <summary>
    /// 撞墙时的角度切换修正
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp > 0)
        {
            transform.Rotate(new Vector3(0, 0, 75));
            Move();
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
    }
}
