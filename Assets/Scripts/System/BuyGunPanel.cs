using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGunPanel : MonoBehaviour {

    //属性-----------------------
    /// <summary>
    /// 是否处于买枪状态
    /// </summary>
    [SerializeField]
    private bool isBuying;
    public bool IsBuying
    {
        get
        {
            return isBuying;
        }
        set
        {
            isBuying = value;
        }
    }

    private GameObject panel;




	// Use this for initialization
	void Start () {
		
        isBuying = false;

    }
	
    public void Buying()
    {
        panel = GameObject.Find("minimap").transform.Find("BuyGunPanel").gameObject;
        panel.SetActive(true);
        isBuying = true;
    }


	
}
