using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private SphereCollider spCollider;

    void Start()
    {
        // �Q�[���I�u�W�F�N�g�ɃA�^�b�`���ꂽ BoxCollider �R���|�[�l���g���擾
        spCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        // ���N���b�N���ꂽ���̂݁ABox Collider ��L��������
        if (Input.GetMouseButtonDown(0))
        {
            spCollider.enabled = true;
        }
        else
        {
            spCollider.enabled = false;
            Debug.Log(false);
        }
    }
}

