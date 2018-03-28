using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    /// <summary>
    /// 相机要跟随的物体
    /// </summary>
    [SerializeField]
    private GameObject player;
    /// <summary>
    /// 相机的刚体控制相机运动
    /// </summary>
    private Rigidbody2D mainRigid;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        mainRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(playerTransform);
        //transform.Translate(new Vector3(playerPos.position.x, playerPos.position.y, -10));
        mainRigid.velocity = player.GetComponent<Rigidbody2D>().velocity;
	}
}
