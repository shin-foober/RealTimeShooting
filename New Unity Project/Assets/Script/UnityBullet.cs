using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBullet : MonoBehaviour
{
    private bool bdirectionflag;
    private int ndirection;
    private int nTimer;
    private int nLimittime;
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        nTimer = 0;
        nLimittime = 3;
        playerObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = playerObj.GetComponent<UnityChan2DController>();

        ndirection = (int)unityChan2DController.fdflag;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ndirection * 0.05f, 0, 0);
        Invoke("Destroy", nLimittime);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (playerObj != coll.gameObject)
        {
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
