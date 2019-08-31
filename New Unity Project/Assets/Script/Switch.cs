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
                On.GetComponent<SpriteRenderer>().enabled = On.GetComponent<SpriteRenderer>().enabled ^ true;
            }
            foreach (GameObject Off in OffObj)
            {
                Off.GetComponent<SpriteRenderer>().enabled = Off.GetComponent<SpriteRenderer>().enabled ^ true;
            }
            foreach (GameObject Des in DestroyObj) //スイッチにより発生するオブジェクトの処理
            {
                Des.GetComponent<SpriteRenderer>().enabled = Des.GetComponent<SpriteRenderer>().enabled ^ true;
                Des.GetComponent<BoxCollider2D>().isTrigger = Des.GetComponent<BoxCollider2D>().isTrigger ^ true;
            }
        }
    }
}