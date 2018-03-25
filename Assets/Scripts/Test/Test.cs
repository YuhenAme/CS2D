using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public float timer ;

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timer <= 0)
            {
                timer = 3;
                Debug.Log("Timer has finished!");
            }
        }


    }
   
}
