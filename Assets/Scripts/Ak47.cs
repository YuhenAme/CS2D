using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Gun {

   
    

    
    //protected override void Shoot()
    //{
        
    //}
    private void Init()
    {
        GetComponent<Ak47>().SetAttackForce(10);
        GetComponent<Ak47>().SetAttackTime(0.6f);
        GetComponent<Ak47>().SetMaxShoot(100);
        //GetComponent<Ak47>().GetComponent<SpriteRenderer>().sprite = ak47;
    }
   
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
}
