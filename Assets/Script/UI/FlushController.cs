using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
     Image img;
    public static FlushController instance;

    //private static bool flushFlag = false;
    float duration = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        
        //�摜�𓧖��ɂ���
        img.color = Color.clear;

        if (!img.enabled)
        {
            img.enabled = true;
        }
    }

   
    //�Ԃ���ʂ�_�ł�����
    public void flush()
    {
        img.color = Color.Lerp(new Color(1.0f, 0.0f, 0.0f, 0.5f), Color.clear,
             Mathf.PingPong(Time.time / duration, 1.0f));
    }

    //�_�ł��I��点��
    public void flushClear()
    {
        img.color = Color.clear;
    }
}
