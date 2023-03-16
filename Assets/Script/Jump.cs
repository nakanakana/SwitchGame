using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    //public Animator animator;
    //MoveControl moveControl;

    private Rigidbody rb;//  Rigidbodyを使うための変数
    private bool Grounded;//  地面に着地しているか判定する変数
    private float Jumppower;//  ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        Jumppower = 10.0f;
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyの値を代入する
    }

    // Update is called once per frame
    void Update()
    {
        //if (moveControl.control)
        //{
            if (Grounded == true)//  もし、Groundedがtrueなら、
            {
                if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
                {
                    //animator.SetTrigger("Jump");
                    Grounded = false;//  Groundedをfalseにする
                                     //animator.SetBool("Grounded", false);
                    rb.AddForce(Vector3.up * Jumppower, ForceMode.Impulse);//  上にJumpPower分力をかける


                }
            }
        //}
    }

    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
            //animator.SetBool("Grounded", true);
        }
    }
}