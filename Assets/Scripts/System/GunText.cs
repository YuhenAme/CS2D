using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunText : MonoBehaviour {

    /// <summary>
    /// 玩家的对象实例
    /// </summary>
    PlayerControll p;
    // Use this for initialization
    void Start () {
        p = GameObject.Find("player").GetComponent<PlayerControll>();
    }
	
	// Update is called once per frame
	void Update () {
        string s = p.TheGun.ToString();
        string a = p.MaxShoot.ToString();
        GetComponent<Text>().text = "<color=#0A0A0A>" + s + "</color>"+"   "+ a;

    }
}
