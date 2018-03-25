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
    /// 枪械的贴图
    /// </summary>
    [SerializeField]
    private Sprite gunSprite;

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
    public Rigidbody2D playerRigid;
    
    //人物所持有的枪械
    //public Gun gun;
    




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
        if (Input.GetMouseButtonDown(0))
        {
            //实例化子弹
            //获得子弹的攻击力，攻击间隔时间
        }
    }

    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = humanSprite;
	}
	
	// Update is called once per frame
	void Update () {
        LookTo();
        Move();
        Hurt();
        Attack();
    }

}
