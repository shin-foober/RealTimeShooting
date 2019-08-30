using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obatacle : MonoBehaviour
{
     public LayerMask whatIsPlayer;
    public AudioClip breakClip;
    private BoxCollider2D m_boxCollider2D;
    private Rigidbody2D[] rigidbody2Ds;
    private Transform[] transforms;
    void Awake()
    {
        rigidbody2Ds = GetComponentsInChildren<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Vector2 pos = transform.position;
            Vector2 groundCheck = new Vector2(pos.x, pos.y - transform.lossyScale.y);
            Vector2 groundArea = new Vector2(m_boxCollider2D.size.x * transform.lossyScale.y * 0.45f, 0.05f);
            var col2D = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsPlayer);
        }
    }
}
