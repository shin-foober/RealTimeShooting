using UnityEngine;
using System.Collections;
public class MainCamera : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数

    private int nfirsttime = 1;

    GameObject playerObj;

    // 各フレームで、Update の後に LateUpdate が呼び出されます。
    void LateUpdate()
    {
        playerObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = playerObj.GetComponent<UnityChan2DController>();
        //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        if (unityChan2DController.m_isGround || 2==nfirsttime) //地面に足がついているときだけカメラ移動
        {
            if (1 == nfirsttime)
            {
                offset = transform.position - player.transform.position;
                nfirsttime = 2;
            }
            transform.position = player.transform.position + offset;
        }
    }
}