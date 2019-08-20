using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
 
  //現状連射は出来ない仕様
  //連射したいならLRボタンと同じ処理に変更
  //発射間隔はUnityContorollerで
    public bool bfire = false;
    public void PushDown()
    {
        var rtf = GetComponent<RectTransform>();
        bfire = true;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 65);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 65);
    }

    public void PushUp()
    {
        var rtf = GetComponent<RectTransform>();
        bfire = false;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
    }
}