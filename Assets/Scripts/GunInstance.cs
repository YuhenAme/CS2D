using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责得到武器实例的类
/// </summary>
public static class GunInstance{
    //根据玩家的GetChild来找物体,待实现

    private static Ak47 ak47Instance;
    /// <summary>
    /// 获取武器实例
    /// </summary>
    public static Ak47 Ak47Instance
    {
        get
        {
            if (ak47Instance == null)
            {
                ak47Instance = GameObject.Find("player").transform.Find("ak47").GetComponent<Ak47>();
                ak47Instance.Init();//之前得到实例的时候没有调用其实例化方法
            }
            return ak47Instance;
        }
    }

    private static Aug augInstance;
    /// <summary>
    /// 获取武器实例
    /// </summary>
    public static Aug AugInstance
    {
        get
        {
            if (augInstance == null)
            {
                augInstance = GameObject.Find("player").transform.Find("aug").GetComponent<Aug>();
                augInstance.Init();
            }
            return augInstance;
        }
    }

    private static Deagle deagleInstance;
    /// <summary>
    /// 获取武器实例
    /// </summary>
    public static Deagle DeagleInstance
    {
        get
        {
            if (deagleInstance == null)
            {
                deagleInstance = GameObject.Find("player").transform.Find("deagle").GetComponent<Deagle>();
                deagleInstance.Init();
            }
            return deagleInstance;
        }
    }

    private static Famas famasInstance;
    public static Famas FamasInstance
    {
        get
        {
            if (famasInstance == null)
            {
                famasInstance = GameObject.Find("player").transform.Find("famas").GetComponent<Famas>();
                famasInstance.Init();
            }
            return famasInstance;
        }
    }

    private static Galil galilInstance;
    public static Galil GalilInstance
    {
        get
        {
            if (galilInstance == null)
            {
                galilInstance = GameObject.Find("player").transform.Find("galil").GetComponent<Galil>();
                galilInstance.Init();
            }
            return galilInstance;
        }
    }

    private static Mp5 mp5Instance;
    public static Mp5 Mp5Instance
    {
        get
        {
            if (mp5Instance == null)
            {
                mp5Instance = GameObject.Find("player").transform.Find("mp5").GetComponent<Mp5>();
                mp5Instance.Init();
            }
            return mp5Instance;
        }
    }

    private static P90 p90Instance;
    public static P90 P90Instance
    {
        get
        {
            if (p90Instance == null)
            {
                p90Instance = GameObject.Find("player").transform.Find("p90").GetComponent<P90>();
                p90Instance.Init();
            }
            return p90Instance;
        }
    }

    private static Scout scoutInstance;
    public static Scout ScoutInstance
    {
        get
        {
            if (scoutInstance == null)
            {
                scoutInstance = GameObject.Find("player").transform.Find("scout").GetComponent<Scout>();
                scoutInstance.Init();
            }
            return scoutInstance;
        }
    }

    private static Usp uspInstance;
    public static Usp UspInstance
    {
        get
        {
            if (uspInstance == null)
            {
                uspInstance = GameObject.Find("player").transform.Find("usp").GetComponent<Usp>();
                uspInstance.Init();
            }
            return uspInstance;
        }
    }

    private static Xm1014 xm1014Instance;
    public static Xm1014 Xm1014Instance
    {
        get
        {
            if (xm1014Instance == null)
            {
                xm1014Instance = GameObject.Find("player").transform.Find("xm1014").GetComponent<Xm1014>();
                xm1014Instance.Init();
            }
            return xm1014Instance;
        }
    }

}
