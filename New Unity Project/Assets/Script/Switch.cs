using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    public GameObject[] OnObj;
    public GameObject[] OffObj;
    public GameObject[] DestroyObj;

    GameObject playerObj;


    // Use this for initialization

    void OnCollisionEnter2D(Collision2D col)
    {
        playerObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = playerObj.GetComponent<UnityChan2DController>();
        if (col.gameObject != playerObj)
        {
            foreach (GameObject On in OnObj)
            {
                On.GetComponent<SpriteRenderer>().enabled = false;
            }
            foreach (GameObject Off in OffObj)
            {
                Off.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (GameObject Des in DestroyObj) //スイッチにより発生するオブジェクトの処理
            {
                Destroy(Des);
            }
             //this.GetComponent<SpriteRenderer>().enabled = false; //当たり判定だけ作っとけばよい
        }
    }
}