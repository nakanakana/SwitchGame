using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public static Alert instance;
    public AudioClip sound;  
    private AudioSource audioSource;
    private bool isAlert = false;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�x�񂪖��Ă���Ή�ʂ�_�ł�����
        if (isAlert)
        {
            FlushController.instance.flush();
        }

    }

    public void OnAleart()
    {
        //�܂����Ă��Ȃ���Ζ炷
        if (!isAlert)
        {
            audioSource.clip = sound;
            audioSource.Play();
            isAlert = true;
        }

    }

    //��ʂ̓_�ł��I��点��
    //�x����~�߂�
    public void ReleaseAleart()
    {    
        FlushController.instance.flushClear();
        audioSource.Stop();
        isAlert = false;
    }

    public bool GetisAlert()
    {
        return isAlert;
    }
}


