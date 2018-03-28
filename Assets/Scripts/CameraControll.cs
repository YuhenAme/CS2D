using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    /// <summary>
    /// 相机要跟随的物体
    /// </summary>
    [SerializeField]
    private GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}
}
