using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour
{

    public GameObject[] TutorialObj;
    public GameObject[] stepobj;
    public GameObject[] step2obj;
    public GameObject[] floorobj;
    public GameObject panel;
    public GameObject Player;
    private bool stepflag;
    private bool levelup;



    void Start()
    {
        stepflag = false;
        levelup = true;
    }

    // Use this for initialization

    //-----------------------------------------------------------------------------
    //
    //処理フロー
    //チュートリアル流れる→Step流れる→Unityちゃん大ジャンプ→床の当たり判定ON＆step2流れる
    //
    //------------------------------------------------------------------------------
    void Update()
    {
    /*     foreach (GameObject start in TutorialObj)
        {
            if (null != start)
            {
                start.GetComponent<Text>().enabled = true;
                start.transform.Translate(20f, 0, 0);
                if (start.transform.position.x > 100)
                {
                    stepflag = true;
                }
                else if (start.transform.position.x > 1500)
                    Destroy(start);
            }
        }
        foreach (GameObject step in stepobj)
        {
            if (stepflag && null != step)
            {
                step.GetComponent<Text>().enabled = true;
                step.transform.Translate(20f, 0, 0);
                if (step.transform.position.x > 1500)
                {
                    Destroy(step);
                }
            }
        }
        foreach (GameObject step2 in step2obj)
        {
            if (!levelup && null != step2)
            {
                step2.GetComponent<Text>().enabled = true;
                step2.transform.Translate(20f, 0, 0);
                if (step2.transform.position.x > 1500)
                {
                    Destroy(step2);
                }
            }
        }*/
        foreach (GameObject floor in floorobj)
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = levelup;　//上の床をONに
        }

        if (Player.transform.position.y > 18) //大ジャンプでしか多分超えられない
        {
            levelup = false;
        }
        else if (Player.transform.position.y < 10)
        {
            levelup = true;
        }
        else
        {
            ;
        }
    }
}

