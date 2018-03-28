using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(State01());
    }
    private IEnumerator State01()
    {
        //Enter
        //...

        while (true)
        {
            Debug.Log("移动");
            //Update
            //StartCoroutine(State02());
            yield return 0;
            //if (Input.GetMouseButtonDown(0))
            //{
            //    StartCoroutine(State02());
            //    break;
            //}
        }

        //Exit
        //...

        //StartCoroutine(State01());
    }

    private IEnumerator State02()
    {
        //Enter
        //...


        while (true)
        {
            //Update
            Debug.Log("02");
            yield return 0;
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(State01());
                break;
            }
        }

        //Exit
        //...

        //StartCoroutine(State02());
    }
    private IEnumerator State03()
    {
        //Enter
        //...

        while (true)
        {
            //Update
            yield return 0;
            if (true/*条件1*/)
            {
                StartCoroutine(State01());
                break;
            }
        }

        //Exit
        //...

        StartCoroutine(State03());
    }
}







