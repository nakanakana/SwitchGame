﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MoveControl : MonoBehaviour
{
    //public enum MyState
    //{
    //    Normal,
    //    Damage,
    //    Attack
    //};

    //public Animator animator;
    private Rigidbody rb;
    private Vector3 moveForward;
    public float moveSpeed;
    private float velocityMax = 1.0f;

    public new GameObject camera;

    float inputHorizontal = 0;
    float inputVertical = 0;

    private const float RotateSpeed = 720f;
    //add
    //{
    //public int lifecount = 0;
    //public int GetLife() { return lifecount; }
    //}

//[SerializeField]
//private GameObject parentObj;

//[SerializeField]
//private GameObject parentObj_;
private bool Grounded;//  地面に着地しているか判定する変数
    private float Jumppower;//  ジャンプ力

    private void FixedUpdate()
    {
        rb.AddForce(moveForward.normalized * moveSpeed, ForceMode.Impulse);
    }

    void Start()
    {
        Jumppower = 0.0f;
        rb = GetComponent<Rigidbody>();

        //add
        //lifecount = 1;

        //Debug.Assert(parentObj != null);
        //Debug.Assert(parentObj_ != null);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //moveForward = (cameraForward * inputVertical) + (Camera.main.transform.right * inputHorizontal);
        moveForward = new Vector3(inputHorizontal, 0, inputVertical);

        //moveForward = (cameraForward * inputVertical) + (camera.transform.right * inputHorizontal);

        //animator.SetFloat("Speed", Mathf.Abs(moveForward.z));

        if ((inputHorizontal != 0) || (inputVertical != 0))
        {
            transform.rotation = Quaternion.LookRotation(moveForward, transform.up);
        }

        //Vector3 direction = InputToDirection();
        //float magnitude = direction.magnitude;

        //if (Mathf.Approximately(magnitude, 0f) == false)
        //{
        //    UpdateRotation(direction);
        //}


        if (rb.velocity.x > velocityMax)
        {
            rb.velocity = new Vector3(0.3f, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < -velocityMax)
        {
            rb.velocity = new Vector3(-0.3f, rb.velocity.y, rb.velocity.z);
        }

        //if (rb.velocity.y > 0.3f)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, 0.3f, rb.velocity.z);
        //}

        if (rb.velocity.z > velocityMax)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.3f);
        }
        if (rb.velocity.z < -velocityMax)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -0.3f);
        }

        //if (Grounded == true)//  もし、Groundedがtrueなら、
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
        //    {
        //        //animator.SetTrigger("Jump");
        //        Grounded = false;//  Groundedをfalseにする
        //                         //animator.SetBool("Grounded", false);
        //        rb.AddForce(Vector3.up * Jumppower, ForceMode.Impulse);//  上にJumpPower分力をかける


        //    }
        //}

        //rb.velocity = moveForward.normalized;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "GameOverArea")
    //    {
    //        //rb.transform.position = new Vector3(1.44f, 2.0f, -3.05f);
    //        SceneManager.LoadScene("SampleScene");
    //    }
    //}

    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
            //animator.SetBool("Grounded", true);
        }
        if (other.gameObject.tag == "Cube")//  もしCubeというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
            //animator.SetBool("Grounded", true);
        }
    }


    //private Vector3 InputToDirection()
    //{
    //    Vector3 direction = new Vector3(0f, 0f, 0f);

    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        direction.x += 1f;
    //    }

    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        direction.x -= 1f;
    //    }

    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        direction.z += 1f;
    //    }

    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        direction.z -= 1f;
    //    }

    //    return direction.normalized;
    //}

    //private void UpdateRotation(Vector3 direction)
    //{
    //    Quaternion from = transform.rotation;
    //    Quaternion to = Quaternion.LookRotation(direction);
    //    transform.rotation = Quaternion.RotateTowards(from, to, RotateSpeed * Time.deltaTime);
    //}


}

