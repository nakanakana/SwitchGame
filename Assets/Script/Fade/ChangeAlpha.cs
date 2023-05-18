using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ChangeAlpha : MonoBehaviour
{
    public static ChangeAlpha instance;

    // �t�F�[�h�����鎞�Ԃ�ݒ�
    [SerializeField]
    private float fadeTime = 1f;
    // �o�ߎ��Ԃ��擾
    private float timer;

    //�t�F�[�h�C���ɐ؂�ւ�������ǂ���
    public bool flagFadeIn = false;

    //�t�F�[�h�C���ƃt�F�[�h�A�E�g�𖳌������邩�ǂ���
    public bool ProgramOn = false;

    // Start is called before the first frame update
    void Start()
    {
        // ���̃Q�[���I�u�W�F�N�g��CanvasGroup�R���|�[�l���g���擾���āA
        // alpha�l��0(�����j�ɂ���B
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;

        //�t�F�[�h�C��������
        flagFadeIn = false;

        //�t�F�[�h�C���A�t�F�[�h�A�E�g�L����
        ProgramOn = true;

        //moveControl = GetComponent<MoveControl>();
        MoveControl.instance.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�t�F�[�h�A�E�g
        if(flagFadeIn == false && ProgramOn == true)
        {
            // �o�ߎ��Ԃ����Z
            timer += Time.deltaTime;
            // �o�ߎ��Ԃ�fadeTime�Ŋ������l��alpha�ɓ����
            // ��alpha�l��1(�s����)���ő�B
            this.gameObject.GetComponent<CanvasGroup>().alpha = timer / fadeTime;

            //alpha�l���Ptimer��8�b�𒴂�����
            if(this.gameObject.GetComponent<CanvasGroup>().alpha == 1 && timer > 8)
            {
                //�t�F�[�h�C���L����
                flagFadeIn = true;
            }
        }

        //�t�F�[�h�C��
        if (flagFadeIn == true && ProgramOn == true)
        {
            //timer -= Time.deltaTime;
            
            //alpha�l����
            this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.002f;

            if (this.gameObject.GetComponent<CanvasGroup>().alpha == 0)
            {
                //�t�F�[�h�C��������
                flagFadeIn = false;

                //�t�F�[�h�C���A�t�F�[�h�A�E�g������
                ProgramOn = false;

                MoveControl.instance.enabled = true;
            }
        }

        //Debug.Log(timer);
    }
}
