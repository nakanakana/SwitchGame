using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleOnMouseDown : MonoBehaviour
{
   
    private bool isMouseDown = false;
    private bool ScaleKeep = false;

    private Vector3 keep_scale;

    private void Awake()
    {
        keep_scale = transform.localScale;
    }

    public void SaveScale()
    {
        keep_scale = transform.localScale;
    }

    public void LoadScale()
    {
        transform.localScale = keep_scale;
    }

    private void Update()
    {
        
        // �}�E�X�̍��{�^�����N���b�N���ꂽ�ꍇ
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;

            ScaleKeep = true;
            SaveScale();


            // DoTween���g�p����Scale���g�傷��
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
        }

        // �}�E�X�̍��{�^���������ꂽ�ꍇ
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

            // DoTween���g�p����Scale�����ɖ߂�
            //transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);

            LoadScale();
            Debug.Log(keep_scale.x);
            Debug.Log(keep_scale.y);
            Debug.Log(keep_scale.z);
        }

        // �}�E�X�̍��{�^�����N���b�N����Ă����
        if (isMouseDown)
        {
            // DoTween���g�p����Scale���g��k��������
            transform.DOScale(new Vector3(2f, 1f, 2f), 0.3f).SetLoops(-1, LoopType.Yoyo);
        }

        
    }
}