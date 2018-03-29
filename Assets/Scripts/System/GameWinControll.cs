using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 判断游戏是否结束的类
/// </summary>
public class GameWinControll : MonoBehaviour {

    //属性-----------------------
    /// <summary>
    /// 判断是否结束
    /// </summary>
    [SerializeField]
    public static bool isOver;




    //方法-----------------------
    /// <summary>
    /// 监听游戏进程，更改isWin
    /// </summary>
    private void OnCheck()
    {
        //普通模式,若CT或T等于0则游戏结束
        //解救模式，CT到人质位置则游戏结束,未实现
        //C4模式，到指定位置则游戏结束，未实现
        GameObject[] ct = GameObject.FindGameObjectsWithTag("CT");
        GameObject[] t = GameObject.FindGameObjectsWithTag("T");
        if (t.Length == 0 || ct.Length == 0)
        {
            Debug.Log("over");
            isOver = true;
            //调用第二场景(游戏主菜单)

        }


    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnCheck();
	}
}
