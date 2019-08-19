using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    // Start is called before the first frame update
    public float fLeft;
    private bool bLeft;

    void Start()
    {
        fLeft = 0f;
        bLeft = false;
    }
    void Update()
    {
        if (fLeft >= -1f && bLeft)
            fLeft -= 0.2f;
        else if (false == bLeft && fLeft <= -0.2f) //徐々に減速するようにする
            fLeft += 0.2f;
    }
    public void PushDown()
    {
        var rtf = GetComponent<RectTransform>();
        bLeft = true;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 65);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 65);
    }

    public void PushUp()
    {
        var rtf = GetComponent<RectTransform>();
        bLeft = false;
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
    }

}