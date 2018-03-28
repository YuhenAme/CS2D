using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    /// <summary>
    /// AI的刚体
    /// </summary>
    [SerializeField]
    private Rigidbody2D aiRigid;

    /// <summary>
    /// AI的血量
    /// </summary>
    [SerializeField]
    private int hp;

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
        idle,
        chase,
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
    /// 更新AI
    /// </summary>
    private void UpdateAI()
    {
        if (IsThink())
        {
            //Debug.Log("思考");
            //敌人开始思考
            AIthinkState(3);
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
            case 2:
                setAIState(State.idle);
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
            Debug.Log("done");
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

        GameObject[] gos = GameObject.FindGameObjectsWithTag("CT");
        foreach (GameObject go in gos)
        {
            //判断敌人与主角之间的距离
            float distance = Vector3.Distance(go.transform.position, transform.position);
            if (distance <= 3)
            {
                if (distance <= 2)
                {
                    setAIState(State.shoot);
                }
                else
                {
                    setAIState(State.chase);
                }
                
            }
        }

            switch (state)
        {
            case State.move:
                Debug.Log("move");
                break;
            case State.rotate:
                Debug.Log("rotate");
                break;
            case State.idle:
                Debug.Log("idle");
                break;
            case State.chase:
                Debug.Log("chase");
                break;
            case State.shoot:
                Debug.Log("shoot");
                break;
            
        }
    }


    // Use this for initialization
    void Start () {
        aiRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAI();
	}
}
