using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class ClearChangeFade : MonoBehaviour
{
    [SerializeField]
    private ClearFadeInpanel m_fade = null;

    //�t�F�[�h�A�E�g�p������
    [SerializeField]
    private float fadeKeepTime = 6.0f;

    private void Start()
    {
        Action on_completed = () =>
        {
            //����������R���[�`�������s
            //StartCoroutine (�R���[�`����, �����ɓn���l);
            StartCoroutine(Wait3SecondsAndFadeOut());
        };

        //m_fade.FadeIn(2.0f, on_completed);
        //m_fade.FadeOut(2.0f, on_completed);
    }

    private IEnumerator Wait3SecondsAndFadeOut()
    {
        //�R���[�`���̓r���ň�莞�Ԓ��f
        yield return new WaitForSeconds(fadeKeepTime);

        m_fade.FadeIn(2.0f);

    }
}
