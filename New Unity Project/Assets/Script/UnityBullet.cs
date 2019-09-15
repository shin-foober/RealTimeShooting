using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBullet : MonoBehaviour
{
    private bool bdirectionflag;
    public int ndirectionLR;
    public int ndirectionUD;
    private float offsetLR;
    private float offsetUD;
    private int nTimer;
    private int nLimittime;

    private int bulletcouse;
    GameObject playerObj;
    Rigidbody2D rigid;
    Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        nLimittime = 0;
        rigid = this.GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = playerObj.GetComponent<UnityChan2DController>();

        ndirectionLR = (int)unityChan2DController.fdflag;
        ndirectionUD = 0;

        bulletcouse = 1;
        offsetLR = 0;
        offsetUD = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (2 == bulletcouse)
        {
            ndirectionLR = -1;
            ndirectionUD = 0;
        }
        else if (4 == bulletcouse)
        {
            ndirectionLR = 1;
            ndirectionUD = 0;
        }
     
     
        transform.Translate(ndirectionLR * 0.3f, ndirectionUD * 0.3f, 0);


     //Unityちゃんの身体に触れているときだけ貫通
     //触れながら移動して長時間弾と一緒に居るとばぐる

        if (true == this.GetComponent<CircleCollider2D>().isTrigger)
        {
            nLimittime += 1;
            if (nLimittime > 3)
            {
                this.GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Reflect")
        {
            bulletcouse = 2;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Reflect1")
        {
            bulletcouse = 3;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Reflect2")
        {
            bulletcouse = 4;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Reflect3")
        {
            bulletcouse = 5;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Player")
        {
            nLimittime = 0;
            this.GetComponent<CircleCollider2D>().isTrigger = true;
        }
        else
        {
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}