using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGunButton : MonoBehaviour {

    /// <summary>
    /// 玩家的对象实例
    /// </summary>
    PlayerControll p;
    // Use this for initialization
    void Start () {
        p = GameObject.Find("player").GetComponent<PlayerControll>();
    }
	
	public void BuyAK47()
    {
        //更改玩家枪械状态
        //先get到player的持枪状态属性gunState，然后ChangeState(gunState)



        //隐藏Panel
        p.panel.SetActive(false);
        p.IsBuying = false;
    }
}
