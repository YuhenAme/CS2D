using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour {

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
        string s = p.hp.ToString();
        if (p.hp >= 70)
        {
            //GetComponent<Text>()..color = Color.red;
            GetComponent<Text>().text = "<color=#00FF00>"+s+"</color>";
        }else if(p.hp>=40&&p.hp<=60)
        {
            GetComponent<Text>().text = "<color=#C0FF3E>" + s + "</color>";
        }
        else
        {
            GetComponent<Text>().text = "<color=#EE0000>" + s + "</color>";
        }
        
	}
}
