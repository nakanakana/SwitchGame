using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //PlayerのAnimatorコンポーネント保存用
    //private Animator animator;

    private Collider swordCollider;

    [SerializeField]
    float attackTime;

    private void Start()
    {
        //PlayerのAnimatorコンポーネントを取得する
        //animator = GetComponent<Animator>();

        //剣のコライダーを取得
        swordCollider = GameObject.Find("P_swordarm").GetComponent<SphereCollider>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetTrigger("IsAttacked");

            //コライダーをオンにする
            swordCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", attackTime);
        }
        
    }

    private void ColliderReset()
    {
        swordCollider.enabled = false;
    }
}