using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    // Start is called before the first frame update
    public float fRight;
    private bool bRight;

    void Start()
    {
        fRight = 0f;
        bRight = false;
    
    }
    void Update()
    {
        if (fRight <= 1f && bRight)
            fRight += 0.2f;
        else if (false == bRight && fRight >= 0.2f)
            fRight -= 0.2f;
    }
    public void PushDown()
    {
        var rtf = GetComponent<RectTransform>();
        bRight = true;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 65);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 65);
    }

    public void PushUp()
    {
        var rtf = GetComponent<RectTransform>();
        bRight = false;
        // 横方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        // 縦方向のサイズ
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
    }

}
