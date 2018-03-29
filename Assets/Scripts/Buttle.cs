using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public  class Buttle : MonoBehaviour {

    /// <summary>
    /// 子弹的刚体
    /// </summary>
    private Rigidbody2D buttleRigid;


    void Start()
    {
        buttleRigid = GetComponent<Rigidbody2D>();
        //exp = GetComponent<Animator>();
    }
    void Update()
    {
       buttleRigid.velocity= transform.TransformDirection(Vector3.up * 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
           
            Destroy(this.gameObject);
        }
    }
}
