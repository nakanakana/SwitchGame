using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private BoxCollider boxCollider;

    void Start()
    {
        // �Q�[���I�u�W�F�N�g�ɃA�^�b�`���ꂽ BoxCollider �R���|�[�l���g���擾
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // ���N���b�N���ꂽ���̂݁ABox Collider ��L��������
        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
            Debug.Log(false);
        }
    }
}

