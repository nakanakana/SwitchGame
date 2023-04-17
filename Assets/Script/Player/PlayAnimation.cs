using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public MoveControl moveControl;

    // 設定したフラグの名前
    private const string key_isWalk = "IsWalk";

    int hpCount;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        if (moveControl == null)
        {
            moveControl = GetComponentInParent<MoveControl>();
        }

        //!!!
        hpCount = moveControl.GetLife();
    }

    // Update is called once per frame
    void Update()
    {

        //Animation
        //Debug.Log(moveControl);

        //ATTACK
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("IsAttacked");

        }


        // ボタンを押下している
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // WaitからRunに遷移する
            this.animator.SetBool(key_isWalk, true);
        }
        else
        {
            // RunからWaitに遷移する
            this.animator.SetBool(key_isWalk, false);
        }

        hpCount = moveControl.GetLife();
        // DAMAGE
        //スペースキーを押下している
        if (/*moveControl.GetLife() < 1*/
            hpCount < 1)
        {
            animator.SetTrigger("IsDamaged");
        }

    }


}

