using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButton : MonoBehaviour
{
    public bool bJump;

    void Start()
    {
        bJump = false;
    }
    public void PushDown()
    {
        var rtf = GetComponent<RectTransform>();
        bJump = true;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 65);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 65);
    }

    public void PushUp()
    {
        var rtf = GetComponent<RectTransform>();
        bJump = false;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
    }
}