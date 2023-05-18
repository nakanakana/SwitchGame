using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ClearFadeInpanel : MonoBehaviour
{
    [SerializeField]
    private Image m_image = null;

   

    /*フェードイン*/
    private void Reset()
    {
        m_image = GetComponent<Image>();
    }

    /// <summary>
    /// フェードインする
    /// </summary>
    public void FadeIn(float duration, Action on_completed = null)
    {
        StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration, on_completed, true));
    }

    /// <summary>
    /// フェードアウトする
    /// </summary>
    //public void FadeOut(float duration, Action on_completed = null)
    //{
    //    StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration, on_completed));
    //}

    //時間経過でアルファ値を変更する(0~1)
    private IEnumerator ChangeAlphaValueFrom0To1OverTime(
    float duration,
    Action on_completed,
    bool is_reversing = false)
    {
        if (!is_reversing) m_image.enabled = true;

        var elapsed_time = 0.0f;
        var color = m_image.color;

        while (elapsed_time < duration)
        {
            var elapsed_rate = Mathf.Min(elapsed_time / duration, 1.0f);
            color.a = is_reversing ? 1.0f - elapsed_rate : elapsed_rate;
            m_image.color = color;

            yield return null;
            elapsed_time += Time.deltaTime;
        }

        if (is_reversing) m_image.enabled = false;
        if (on_completed != null) on_completed();
    }
}
