using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour {

    public GameObject[] pos;
    public float moveSpeed=5.0f;
    //public Vector2[] path;
	// Use this for initialization
	void Start () {
        pos = GameObject.FindGameObjectsWithTag("Position");
        

    }


    IEnumerator MoveOnPath(bool loop)
    {
        do
        {
            foreach (var point in pos)
                yield return StartCoroutine(MoveToPosition(point));
        }
        while (loop);
    }

    IEnumerator MoveToPosition(GameObject go)
    {
        while (transform.position != go.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, go.transform.position, moveSpeed );
            yield return 0;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
