using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Player��Animator�R���|�[�l���g�ۑ��p
    //private Animator animator;

    private Collider swordCollider;

    [SerializeField]
    float attackTime;

    private void Start()
    {
        //Player��Animator�R���|�[�l���g���擾����
        //animator = GetComponent<Animator>();

        //���̃R���C�_�[���擾
        swordCollider = GameObject.Find("P_swordarm").GetComponent<SphereCollider>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetTrigger("IsAttacked");

            //�R���C�_�[���I���ɂ���
            swordCollider.enabled = true;

            //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
            Invoke("ColliderReset", attackTime);
        }
        
    }

    private void ColliderReset()
    {
        swordCollider.enabled = false;
    }
}