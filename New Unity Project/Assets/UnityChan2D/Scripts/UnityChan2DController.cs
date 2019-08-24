using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class UnityChan2DController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpPower = 1000f;
    public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);

    public LayerMask whatIsGround;

    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private const float m_centerY = 1.5f;

    private State m_state = State.Normal;
    private int nfirstjump;
    public float fdflag;  //最初右向きなら1違うなら-1を設定

    private bool bbulletflag;
    private int nflame;

    public GameObject bulletPrefab;  //弾丸のprefab

    GameObject refObjUP; //ボタン操作取得のために追加　↑ 用
    GameObject refObjR; //ボタン操作取得のために追加　→ 用
    GameObject refObjL; //ボタン操作取得のために追加　←　用
    GameObject refObjF; //ボタン操作取得のために追加　弾発射用


    ///////////////////////////////////////////////////////////////
    //              初期化
    //////////////////////////////////////////////////////////////
    void Reset()
    {
        Awake();
        // UnityChan2DController
        maxSpeed = 10f;
        jumpPower = 1000;
        backwardForce = new Vector2(-4.5f, 5.4f);
        whatIsGround = 1 << LayerMask.NameToLayer("Ground");

        // Transform
        transform.localScale = new Vector3(1, 1, 1);

        // Rigidbody2D
        m_rigidbody2D.gravityScale = 3.5f;
        m_rigidbody2D.fixedAngle = true;

        // BoxCollider2D
        m_boxcollier2D.size = new Vector2(1, 2.5f);
        m_boxcollier2D.offset = new Vector2(0, -0.25f);

        // Animator
        m_animator.applyRootMotion = false;

        
        // Adjustparameter
        nfirstjump = 0;
        bbulletflag = true;
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        refObjUP = GameObject.Find("UpButtan");      //最終的に各オブジェクトをタグ付けした方がいい　処理時間を減らすため
        refObjR = GameObject.Find("RightButton");
        refObjL = GameObject.Find("LeftButton");
        refObjF = GameObject.Find("FireButton");
        fdflag = 1;
    }

    /////////////////////////////////////////////////
    //         メイン処理
    ////////////////////////////////////////////////
    void Update()
    {
        UpButton upButton = refObjUP.GetComponent<UpButton>();
        RightButton rightButton = refObjR.GetComponent<RightButton>();
        LeftButton leftButton = refObjL.GetComponent<LeftButton>();
        FireButton fireButton = refObjF.GetComponent<FireButton>();
        if (m_state != State.Damaged)
        {
            float x = rightButton.fRight + leftButton.fLeft;
            bool jump = upButton.bJump;

            Move(x, jump);

            // 弾の発射処理
            if (fireButton.bfire && bbulletflag)
                Shot();

            if (false == jump) //ジャンプが二回読み込まれてしまったので一回だけにするように調整　
                nfirstjump = 0;

            if (false == fireButton.bfire && 1 == nflame % 30) //取り敢えず30fに一度の発射で false == fireButton.bfireは高速発射防止のため追加
                bbulletflag = true;

            if (false == bbulletflag) //発射不能時のみカウント
                nflame += 1;
        }
    }

    /////////////////////////////////////////////////////
    //　　　　　発射処理
    /////////////////////////////////////////////////////
    void Shot()
    {
        Instantiate(bulletPrefab, new Vector3(transform.position.x + fdflag * 0.5f, transform.position.y + 0.5f, 0), Quaternion.identity);

        bbulletflag = false; //発射したらフラグをoff カウントをリセット
        nflame = 0;
    }

    ///////////////////////////////////////////////////
    //  　　　キャラ移動処理
    //////////////////////////////////////////////////
    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
            fdflag = Mathf.Sign(move);
        }

        m_rigidbody2D.velocity = new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y);

        m_animator.SetFloat("Horizontal", move);
        m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        m_animator.SetBool("isGround", m_isGround);

        if (jump && m_isGround && 0 == nfirstjump)
        {
            m_animator.SetTrigger("Jump");
            SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            nfirstjump += 1;
            Invoke("jump", 0.02f); //落下直後にジャンプするとなぜか飛び上がらないためaddforceのみ処理を遅らせる
        }
    }
    void jump()
    {
        m_rigidbody2D.AddForce(Vector2.up * jumpPower);
    }

    //////////////////////////////////////////////////////////////////
    // 　　　　updateより短い周期で周回
    /////////////////////////////////////////////////////////////////
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
        Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);

        m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
        m_animator.SetBool("isGround", m_isGround);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "DamageObject" && m_state == State.Normal)
        {
            m_state = State.Damaged;
            StartCoroutine(INTERNAL_OnDamage());
        }
    }

    IEnumerator INTERNAL_OnDamage()
    {
        m_animator.Play(m_isGround ? "Damage" : "AirDamage");
        m_animator.Play("Idle");

        SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);

        m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);

        yield return new WaitForSeconds(.2f);

        while (m_isGround == false)
        {
            yield return new WaitForFixedUpdate();
        }
        m_animator.SetTrigger("Invincible Mode");
        m_state = State.Invincible;
    }

    void OnFinishedInvincibleMode()
    {
        m_state = State.Normal;
    }

    enum State
    {
        Normal,
        Damaged,
        Invincible,
    }
}
