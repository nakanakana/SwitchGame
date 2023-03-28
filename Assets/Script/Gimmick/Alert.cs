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
        //警報が鳴っていれば画面を点滅させる
        if (isAlert)
        {
            FlushController.instance.flush();
        }

    }

    public void OnAleart()
    {
        //まだ鳴っていなければ鳴らす
        if (!isAlert)
        {
            audioSource.clip = sound;
            audioSource.Play();
            isAlert = true;
        }

    }

    //画面の点滅を終わらせる
    //警報を止める
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


