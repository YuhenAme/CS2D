using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTest : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;
    /// <summary>
    /// 枪的枚举类型
    /// </summary>
    private enum GunType
    {
        ak47,
        aug,
        deagle,
        famas,
        galil,
        mp5,
        p90,
        scout,
        xm1014,
        usp
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Hurt(GunType gunBullet)
    {
        //受到伤害
        Debug.Log(gunBullet.ToString());
        switch (gunBullet)
        {
            case GunType.ak47://Debug.Log(gunBullet.ToString());
                hp -= 15;
                break;
            case GunType.aug:
                hp -= 15;
                break;
            case GunType.deagle:
                hp -= 9;
                break;
            case GunType.famas:
                hp -= 25;
                break;
            case GunType.galil:
                hp -= 25;
                break;
            case GunType.mp5:
                hp -= 10;
                break;
            case GunType.p90:
                hp -= 9;
                break;
            case GunType.scout:
                hp -= 35;
                break;
            case GunType.usp:
                hp -= 9;
                break;
            case GunType.xm1014:
                hp -= 30;
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("done");
        //与子弹发生碰撞
        //子弹类型
        GunType gunbullet;
        //与子弹发生碰撞
        for (gunbullet = GunType.ak47; gunbullet <= GunType.usp; gunbullet++)
        {
            //Debug.Log("d");
            if (gunbullet.ToString() + "Buttle" == collision.gameObject.name)
            {
                
                break;
            }
        }
        Debug.Log(gunbullet.ToString());
        Hurt(gunbullet);
    }
}