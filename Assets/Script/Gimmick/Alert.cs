using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public static Alert instance;
    [Header("�A���[�g�����Z�b�g�B�ʂɎw�肵�Ȃ��Ȃ炱�ꂪ��")]
    public AudioClip sound;  

    private AudioSource audioSource;
    private bool isAlert = false; //���Ă��邩�ǂ���
    private bool isCall = false;�@//�G���Ă�ł��邩�ǂ���
    private GameObject[] enemy;

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
            //FlushController.instance.flush();
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

    //�O�����特�����w�肵���ꍇ
    public void OnAleart(AudioClip so)
    {
        //�܂����Ă��Ȃ���Ζ炷
        if (!isAlert)
        {
            audioSource.clip = so;
            audioSource.Play();
            isAlert = true;
        }

    }


    //��ʂ̓_�ł��I��点��
    //�x����~�߂�
    public void ReleaseAleart()
    {    
       // FlushController.instance.flushClear();
        audioSource.Stop();
        ReleaseEnemy();
        isAlert = false;
    }

    public bool GetisAlert()
    {
        return isAlert;
    }

    public void CallEnemy(GameObject[] enemies,Transform tr)
    {
        enemy = enemies;
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponentInChildren<Patrol>().AlertCome(tr);
            }
        }
    }


    public void ReleaseEnemy()
    {
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (enemy[i] != null)
            {
                enemy[i].GetComponentInChildren<Patrol>().Return();
            }
        }

    }


}


