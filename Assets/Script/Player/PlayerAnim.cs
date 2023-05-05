using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    public MoveControl moveControl;

    float DelayTimer = 5.0f; 

    // �ݒ肵���t���O�̖��O
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

        DelayTimer = 5.0f;


        //!!!
        //hpCount = moveControl.GetLife();
    }

    // Update is called once per frame
    void Update()
    {

        //Animation
        //Debug.Log(moveControl);

        //ATTACK
        //DelayTimer -= Time.deltaTime;
        //if (DelayTimer <= 3.0f)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("IsAttacked");
                //DelayTimer = 5.0f;
            }
       // }
        


        // �{�^�����������Ă���
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Wait����Run�ɑJ�ڂ���
            this.animator.SetBool(key_isWalk, true);
        }
        else
        {
            // Run����Wait�ɑJ�ڂ���
            this.animator.SetBool(key_isWalk, false);
        }

        //hpCount = moveControl.GetLife();
        // DAMAGE
        //�X�y�[�X�L�[���������Ă���
        //if (/*moveControl.GetLife() < 1*/
        //    hpCount < 1)
        //{
        //    animator.SetTrigger("IsDamaged");
        //}

    }

}

