using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public float timer =3;
    public enum Tip
    {
        a,
        b,
        c,
        d
    }

    void Update()
    {
        Tip tip = Tip.a;
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timer <= 0)
            {
                timer = 3;
                Debug.Log("Timer has finished!");
            }
        }
        //Debug.Log(tip.ToString()+"_d");
        //if (tip.ToString() + "_d" == "a_d")
        //{
        //    Debug.Log("ok");
        //}
        Tip t;
        for (t = Tip.a; t <= Tip.d; t++)
        {
            //Debug.Log(t.ToString());
            if (t.ToString() + "_d" == "c_d")
            {
                //Debug.Log("done");
                tip = t;
                Debug.Log(tip.ToString());
                break;
            }
        }

    }
   
}
