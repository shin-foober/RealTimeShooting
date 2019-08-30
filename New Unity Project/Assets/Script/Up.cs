using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    // Start is called before the first frame update     public LayerMask whatIsPlayer;
    public LayerMask whatIsPlayer;
    public AudioClip breakClip;
    private BoxCollider2D m_boxCollider2D;
    public bool bigjump;
    void Awake()
    {
        m_boxCollider2D = GetComponent<BoxCollider2D>();
        bigjump = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Vector2 pos = transform.position;
            Vector2 groundCheck = new Vector2(pos.x, pos.y - transform.lossyScale.y);
            Vector2 groundArea = new Vector2(m_boxCollider2D.size.x * transform.lossyScale.y * 0.45f, 0.05f);
            var col2D = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsPlayer);
                 
            bigjump = true; //ジャンプフラグをON
        }
    }
}
