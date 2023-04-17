using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public MoveControl moveControl;

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

        hpCount = moveControl.GetLife();
        // DAMAGE
        //�X�y�[�X�L�[���������Ă���
        if (/*moveControl.GetLife() < 1*/
            hpCount < 1)
        {
            animator.SetTrigger("IsDamaged");
        }

    }


}

