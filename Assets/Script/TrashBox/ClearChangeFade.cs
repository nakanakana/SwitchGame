using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class ClearChangeFade : MonoBehaviour
{
    [SerializeField]
    private ClearFadeInpanel m_fade = null;

    //フェードアウト継続時間
    [SerializeField]
    private float fadeKeepTime = 6.0f;

    private void Start()
    {
        Action on_completed = () =>
        {
            //引数があるコルーチンを実行
            //StartCoroutine (コルーチン名, 引数に渡す値);
            StartCoroutine(Wait3SecondsAndFadeOut());
        };

        //m_fade.FadeIn(2.0f, on_completed);
        //m_fade.FadeOut(2.0f, on_completed);
    }

    private IEnumerator Wait3SecondsAndFadeOut()
    {
        //コルーチンの途中で一定時間中断
        yield return new WaitForSeconds(fadeKeepTime);

        m_fade.FadeIn(2.0f);

    }
}
