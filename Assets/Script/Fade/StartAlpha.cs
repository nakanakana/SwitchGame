using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAlpha : MonoBehaviour
{


    // �t�F�[�h�����鎞�Ԃ�ݒ�
    [SerializeField]
    private float fadeTime = 0.0f;
    // �o�ߎ��Ԃ��擾
    private float timer;

    //�t�F�[�h�C���ɐ؂�ւ�������ǂ���
    public bool flagFadeIn = false;

    //�t�F�[�h�C���ƃt�F�[�h�A�E�g�𖳌������邩�ǂ���
    public bool programOn = true;

   
    //[SerializeField] GameObject loading;

   


    // Start is called before the first frame update
    void Start()
    {
        // ���̃Q�[���I�u�W�F�N�g��CanvasGroup�R���|�[�l���g���擾���āA
        // alpha�l��0(�����j�ɂ���B
        //this.gameObject.GetComponent<CanvasGroup>().alpha = 1;

        //�t�F�[�h�C��������
        flagFadeIn = true;

        //�t�F�[�h�C���A�t�F�[�h�A�E�g�L����
        programOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        ////�t�F�[�h�A�E�g
        //if (flagFadeIn == false && programOn == true)
        //{
        //    // �o�ߎ��Ԃ����Z
        //    timer += Time.deltaTime;
        //    //// �o�ߎ��Ԃ�fadeTime�Ŋ������l��alpha�ɓ����
        //    //// ��alpha�l��1(�s����)���ő�B
        //    this.gameObject.GetComponent<CanvasGroup>().alpha += timer / fadeTime;
        //    ////alpha�l���Ptimer��8�b�𒴂�����
        //    if (this.gameObject.GetComponent<CanvasGroup>().alpha == 1)
        //    {
             
        //        if (timer >= 1.0f)
        //        {
        //            if (!loading.activeSelf)
        //            {
        //                loading.SetActive(true);
        //            }
        //        }
        //    }
        //}

        ////�t�F�[�h�C��
        if (flagFadeIn == true && programOn == true)
        {
            timer += Time.deltaTime;

            //alpha�l����
            //this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.02f;
            this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.009f;
            if (this.gameObject.GetComponent<CanvasGroup>().alpha <= 0.0f)
            {
                //�t�F�[�h�C��������
                flagFadeIn = false;

                //�t�F�[�h�C���A�t�F�[�h�A�E�g������
                programOn = false;

               // this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            }
        }

        
    }
}
