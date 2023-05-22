using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveControl : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveForward;
    private Collider PlayerCollider;

    public new GameObject camera;
    public static MoveControl instance;

    private float velocityMax = 1.0f;
    public float moveSpeed;

    float inputHorizontal = 0;
    float inputVertical = 0;
    float nowSceneTimer = 0;

    private const float RotateSpeed = 720f;
    private const string key_isWalk = "IsWalk";

    public bool hitEnemy = false;

    public bool isAttack = true;

    private bool Grounded;//  地面に着地しているか判定する変数

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        this.animator = GetComponent<Animator>();

        hitEnemy = false;

        PlayerCollider = GameObject.Find("Player").GetComponent<CapsuleCollider>();
       // PlayerCollider.enabled = true;
        SceneManager.GetActiveScene();
 
    }

    private void FixedUpdate()
    {
        if (!hitEnemy)
            rb.AddForce(moveForward.normalized * moveSpeed, ForceMode.Impulse);
    }
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical"); 

        moveForward = new Vector3(inputHorizontal, 0, inputVertical);

        if (!hitEnemy)
        {
            if ((inputHorizontal != 0) || (inputVertical != 0))
            {
                transform.rotation = Quaternion.LookRotation(moveForward, transform.up);
            }

            if (rb.velocity.x > velocityMax)
            {
                rb.velocity = new Vector3(0.3f, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.x < -velocityMax)
            {
                rb.velocity = new Vector3(-0.3f, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.z > velocityMax)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.3f);
            }
            if (rb.velocity.z < -velocityMax)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -0.3f);
            }



            // ボタンを押下している
            if (
                //キー入力
                Input.GetKey(KeyCode.W) || 
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) || 
                Input.GetKey(KeyCode.D) ||
                //ゲームパッド
                inputHorizontal != 0 ||
                inputVertical != 0)
            {
                // WaitからRunに遷移する
                this.animator.SetBool(key_isWalk, true);
            }
            else
            {
                // RunからWaitに遷移する
                this.animator.SetBool(key_isWalk, false);
            }

            //Animation
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("IsAttacked");

            }
        }
        else
        {
            //シーンタイマーに足す
            nowSceneTimer += Time.deltaTime;
        }

      

        //if (!hitEnemy)
        //{
        //    // ボタンを押下している
        //    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //    {
        //        // WaitからRunに遷移する
        //        this.animator.SetBool(key_isWalk, true);
        //    }
        //    else
        //    {
        //        // RunからWaitに遷移する
        //        this.animator.SetBool(key_isWalk, false);
        //    }
        //}

        // Player死んだら
        //if (hitEnemy == true)
        //{
        //    //シーンタイマーに足す
        //    nowSceneTimer += Time.deltaTime;
        //}

        //シーンタイマーが3秒過ぎたら
        if (nowSceneTimer >= 3.0f)
        {
            //シーンリロード
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

}

  
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする    
        }
        if (other.gameObject.tag == "Cube")//  もしCubeというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;
        }

    }

    //殺す処理
    public void OnDead()
    {
        if (!HitEnemy)
        {
            HitEnemy = true;
            animator.SetTrigger("IsDied");
            gameObject.layer = LayerMask.NameToLayer("DammyPlayer");

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")// もしBulletというタグがついたオブジェクトに触れたら、
        {
            OnDead();
        }

}
    public bool HitEnemy
    {
        get
        {
            Debug.Log("Accessed to parameter.");
            Debug.Log(hitEnemy);
            return hitEnemy;
        }
        set
        {
            hitEnemy = value;
        }

    }

    public bool IsAttack
    {
        get
        {
            return isAttack;
        }
        set
        {
            isAttack = value;
        }

    }

}

